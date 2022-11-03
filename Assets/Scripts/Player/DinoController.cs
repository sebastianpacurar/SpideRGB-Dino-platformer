using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class DinoController : MonoBehaviour {
        private DinoAnimState _animState;

        private PlayerControls _controls;
        private float _input;
        private bool _jumpPressed;

        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundedPos;

        [SerializeField] private float speed = 2f;
        [SerializeField] private float jumpForce = 5f;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Animator _animator;

        private void Awake() {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update() {
            Move();
        }

        private void FixedUpdate() {
            ApplyVelocity();
            UpdateAnimationState();
        }

        // first check for the jump functionality, then update on X axis
        private void ApplyVelocity() {
            if (_jumpPressed && IsGrounded()) {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y + jumpForce);
            }

            _rb.velocity = new Vector2(_input * speed, _rb.velocity.y);
        }

        private void Move() {
            _input = _controls.Dino.Move.ReadValue<float>();
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

        private bool IsGrounded() {
            return Physics2D.OverlapCapsule(groundedPos.position, new Vector2(0.7f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        }

        private void OnEnable() {
            _controls.Dino.Move.Enable();
            _controls.Dino.Jump.Enable();
            _controls.Dino.Jump.performed += Jump;
            _controls.Dino.Jump.canceled += Jump;
        }

        private void OnDisable() {
            _controls.Dino.Jump.performed -= Jump;
            _controls.Dino.Jump.canceled -= Jump;
            _controls.Dino.Jump.Disable();
            _controls.Dino.Move.Disable();
        }

        private void UpdateAnimationState() {
            if (_rb.velocity.x < 0f || _rb.velocity.x > 0f) {
                if (IsGrounded()) {
                    _animState = DinoAnimState.running;
                }

                if (_rb.velocity.x < 0f) {
                    _sr.flipX = true;
                } else if (_rb.velocity.x > 0f) {
                    _sr.flipX = false;
                }
            } else if (_rb.velocity.y > 0f && !IsGrounded()) {
                _animState = DinoAnimState.jumping;
            } else if (_rb.velocity.y < 0f && !IsGrounded()) {
                _animState = DinoAnimState.falling;
            } else {
                _animState = DinoAnimState.idle;
            }

            _animator.SetInteger("state", (int)_animState);
        }
    }
}