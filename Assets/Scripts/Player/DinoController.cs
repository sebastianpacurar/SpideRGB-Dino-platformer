using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class DinoController : MonoBehaviour {
        private PlayerControls _controls;
        private float _input;
        private bool _jumpPressed;

        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundedPos;

        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpForce = 5f;

        private Rigidbody2D _rb;

        private void Awake() {
            _controls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            Move();
        }

        private void FixedUpdate() {
            ApplyVelocity();
        }

        private void ApplyVelocity() {
            if (_jumpPressed && IsGrounded()) {
                var velocity = _rb.velocity;
                velocity = new Vector2(velocity.x, velocity.y + jumpForce);

                _rb.velocity = velocity;
            }

            _rb.AddForce(new Vector2(_input * speed * Time.deltaTime, 0), ForceMode2D.Impulse);
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
    }
}