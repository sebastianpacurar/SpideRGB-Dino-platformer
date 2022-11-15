using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class DinoController : MonoBehaviour {
        private DinoAnimState _animState;

        private PlayerControls _controls;
        private float _input;
        private bool _jumpPressed;

        // used to override all other animations by Hit animation
        public bool IsHit { get; set; }

        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpForce = 10f;

        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundedPos;

        [SerializeField] private SpriteRenderer shadowSprite;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Animator _animator;
        private CinemachineVirtualCamera _cineMachineCam;
        private ParticleSystem _ps;

        private void Awake() {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            _cineMachineCam = GameObject.FindGameObjectWithTag("CM2D").GetComponent<CinemachineVirtualCamera>();
            _cineMachineCam.Follow = transform;
            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            name = $"{GetComponent<SwitchDino>().DinoType} Dino";
        }

        private void Update() {
            Move();
            CreateTrail();
        }

        private void FixedUpdate() {
            ApplyVelocity();
            UpdateAnimationState();
            FlipDino();
            UpdateDinoShadow();
        }

        // first check for the jump functionality, then update on X axis
        private void ApplyVelocity() {
            if (_jumpPressed) {
                var velocity = _rb.velocity;
                _rb.velocity = new Vector2(velocity.x, velocity.y + jumpForce);
                _jumpPressed = false;
            }

            _rb.velocity = new Vector2(_input * speed, _rb.velocity.y);
        }

        private void CreateTrail() {
            if (_input != 0 && IsGrounded()) {
                _ps.Play();
            } else {
                if (_ps.isPlaying) {
                    _ps.Stop();
                }
            }
        }

        private void UpdateDinoShadow() {
            shadowSprite.enabled = IsGrounded();
        }

        private bool IsGrounded() {
            return Physics2D.OverlapCapsule(groundedPos.position, new Vector2(0.5f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        }

        private void Move() {
            _input = _controls.Dino.Move.ReadValue<float>();
        }

        private void Jump(InputAction.CallbackContext ctx) {
            switch (ctx.phase) {
                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    if (IsGrounded()) {
                        _jumpPressed = true;
                    }

                    break;
            }
        }

        private void OnEnable() {
            _controls.Dino.Move.Enable();
            _controls.Dino.Jump.Enable();
            _controls.Dino.Jump.performed += Jump;
        }

        private void OnDisable() {
            _controls.Dino.Jump.performed -= Jump;
            _controls.Dino.Jump.Disable();
            _controls.Dino.Move.Disable();
        }

        private void UpdateAnimationState() {
            if (!IsHit) {
                if (_rb.velocity.x is < 0f or > 0f && IsGrounded()) {
                    _animState = DinoAnimState.running;
                } else if (_rb.velocity.y > 0f && !IsGrounded()) {
                    _animState = DinoAnimState.jumping;
                } else if (_rb.velocity.y < 0f && !IsGrounded()) {
                    _animState = DinoAnimState.falling;
                } else {
                    _animState = DinoAnimState.idle;
                }
            } else {
                _animState = DinoAnimState.hit;
            }

            _animator.SetInteger("state", (int)_animState);
        }

        private void FlipDino() {
            var velocityOverLifetimeModule = _ps.velocityOverLifetime;
            switch (_rb.velocity.x) {
                case < 0f:
                    _sr.flipX = true;
                    velocityOverLifetimeModule.x = 0.1f;
                    break;
                case > 0f:
                    velocityOverLifetimeModule.x = -0.1f;
                    _sr.flipX = false;
                    break;
            }
        }

        // called in Hit animation at the end of the anim timeline
        private void StopHitAnimation() {
            IsHit = false;
        }
    }
}