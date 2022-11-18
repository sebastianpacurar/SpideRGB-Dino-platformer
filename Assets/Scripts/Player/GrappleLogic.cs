using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class GrappleLogic : MonoBehaviour {
        private PlayerControls _controls;
        private GameObject _grappleArea;

        private LineRenderer _lineRenderer;
        private SpringJoint2D _springJoint2D;

        // the clicked platform node's RigidBody
        private Rigidbody2D _selectedNodeRb;
        private bool _isPulling, _isPushing;

        private DinoController _controller;

        // used to prevent OnTriggerExit to deselect node if another platform exits the BoxCollider area
        public string SelectedPlatformName { get; private set; } = string.Empty;
        public float GrappleMaxDistance { get; set; }


        private void Awake() {
            _controls = new PlayerControls();
            _lineRenderer = GetComponent<LineRenderer>();
            _springJoint2D = GetComponent<SpringJoint2D>();
        }

        private void Start() {
            _controller = transform.gameObject.GetComponent<DinoController>();

            _lineRenderer.startWidth = 0.2f;
            _lineRenderer.endWidth = 0.2f;
            _lineRenderer.enabled = false;
            _lineRenderer.startColor = MyColor.Green;
            _lineRenderer.endColor = MyColor.Green;
            _springJoint2D.enabled = false;
        }


        private void Update() {
            HandleGrapplingHook();
        }

        private void Pull(InputAction.CallbackContext ctx) {
            switch (ctx.phase) {
                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    _isPulling = true;
                    break;
                case InputActionPhase.Canceled:
                    _isPulling = false;
                    break;
            }
        }

        private void Push(InputAction.CallbackContext ctx) {
            switch (ctx.phase) {
                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    _isPushing = true;
                    break;
                case InputActionPhase.Canceled:
                    _isPushing = false;
                    break;
            }
        }

        // called in GrappleNode.cs upon OnPointerDown event
        public void SelectNode(GrappleNode node) {
            _selectedNodeRb = node.GetComponent<Rigidbody2D>();
            // assign the name of the grandparent, which contains the generated GUID
            SelectedPlatformName = node.transform.parent.transform.parent.name;
        }

        // called in GrappleNode.cs upon OnPointerUp event
        public void DeselectNode() {
            _selectedNodeRb = null;
            SelectedPlatformName = string.Empty;
        }

        private void HandleGrapplingHook() {
            if (_selectedNodeRb) {
                var position = _selectedNodeRb.transform.position;

                _lineRenderer.enabled = true;
                _springJoint2D.enabled = true;
                _springJoint2D.connectedBody = _selectedNodeRb;

                // set initial distance to the distance between the dino and target platform 
                _springJoint2D.distance = Vector2.Distance(gameObject.transform.position, position);

                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, position);

                // Handle Pull Grapple update
                if (_isPulling && _springJoint2D.distance >= 2.5f) {
                    _springJoint2D.distance -= 0.3f;
                }

                // Handle Push Grapple update
                if (!_controller.IsGrounded() && _isPushing && _springJoint2D.distance <= GrappleMaxDistance) {
                    _springJoint2D.distance += 0.3f;
                }

                if (_springJoint2D.distance >= GrappleMaxDistance) {
                    _springJoint2D.distance = GrappleMaxDistance;
                }
            } else {
                _lineRenderer.enabled = false;
                _springJoint2D.enabled = false;
            }
        }

        private void OnEnable() {
            _controls.Dino.Push.Enable();
            _controls.Dino.Pull.Enable();

            _controls.Dino.Pull.performed += Pull;
            _controls.Dino.Pull.canceled += Pull;

            _controls.Dino.Push.performed += Push;
            _controls.Dino.Push.canceled += Push;
        }

        private void OnDisable() {
            _controls.Dino.Pull.performed -= Pull;
            _controls.Dino.Pull.canceled -= Pull;

            _controls.Dino.Push.performed -= Push;
            _controls.Dino.Push.canceled -= Push;

            _controls.Dino.Push.Disable();
            _controls.Dino.Pull.Disable();
        }
    }
}