using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class DinoController : MonoBehaviour {
        private DinoAnimState _animState;

        private PlayerControls _controls;
        private float _input;
        private bool _jumpPressed;

        [SerializeField] private Vector2 aimVector;

        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundedPos;
        [SerializeField] private SpriteRenderer shadowSprite;

        [SerializeField] private float speed = 2f;
        [SerializeField] private float jumpForce = 5f;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Animator _animator;
        private Camera _mainCam;

        private void Awake() {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();

            _animator = GetComponent<Animator>();
            _mainCam = Camera.main;
        }


        private void Update() {
            Move();
            Aim();
            UpdateCameraPos();
        }

        private void FixedUpdate() {
            ApplyVelocity();
            UpdateAnimationState();
            FlipDino();
            UpdateDinoShadow();
        }

        // first check for the jump functionality, then update on X axis
        private void ApplyVelocity() {
            if (_jumpPressed && IsGrounded()) {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y + jumpForce);
            }

            _rb.velocity = new Vector2(_input * speed, _rb.velocity.y);
        }

        private void UpdateCameraPos() {
            var dinoPos = transform.position;
            var cam = _mainCam.transform;
            cam.position = new Vector3(dinoPos.x, dinoPos.y, cam.position.z);
        }

        private void UpdateDinoShadow() {
            shadowSprite.enabled = IsGrounded();
        }

        private bool IsGrounded() {
            return Physics2D.OverlapCapsule(groundedPos.position, new Vector2(0.5f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        }

        private void Move() {
            _input = _controls.Dino.Move.ReadValue<float>();
        }

        private void Aim() {
            var points = _controls.Dino.Aim.ReadValue<Vector2>();
            aimVector = _mainCam.ScreenToWorldPoint(points);
            Debug.Log(aimVector);
        }

        private void Jump(InputAction.CallbackContext ctx) {
            switch (ctx.phase) {
                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    _jumpPressed = true;
                    break;
                case InputActionPhase.Canceled:
                    _jumpPressed = false;
                    break;
            }
        }

        private void OnEnable() {
            _controls.Dino.Move.Enable();
            _controls.Dino.Jump.Enable();
            _controls.Dino.Aim.Enable();
            _controls.Dino.Jump.performed += Jump;
            _controls.Dino.Jump.canceled += Jump;
        }

        private void OnDisable() {
            _controls.Dino.Jump.performed -= Jump;
            _controls.Dino.Jump.canceled -= Jump;
            _controls.Dino.Aim.Disable();
            _controls.Dino.Jump.Disable();
            _controls.Dino.Move.Disable();
        }

        private void UpdateAnimationState() {
            if ((_rb.velocity.x < 0f || _rb.velocity.x > 0f) && IsGrounded()) {
                _animState = DinoAnimState.running;
            } else if (_rb.velocity.y > 0f && !IsGrounded()) {
                _animState = DinoAnimState.jumping;
            } else if (_rb.velocity.y < 0f && !IsGrounded()) {
                _animState = DinoAnimState.falling;
            } else {
                _animState = DinoAnimState.idle;
            }

            _animator.SetInteger("state", (int)_animState);
        }

        private void FlipDino() {
            if (_rb.velocity.x < 0f) {
                _sr.flipX = true;
            } else if (_rb.velocity.x > 0f) {
                _sr.flipX = false;
            }
        }
    }
}