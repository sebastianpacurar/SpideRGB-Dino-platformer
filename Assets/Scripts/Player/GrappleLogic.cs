using Platforms;
using UnityEngine;

namespace Player {
    public class GrappleLogic : MonoBehaviour {
        private GameObject _grappleArea;

        private LineRenderer _lineRenderer;
        private SpringJoint2D _springJoint2D;

        // the reference to "Grapple Node" game object
        public Rigidbody2D SelectedNodeRb { get; private set; }

        private void Awake() {
            _lineRenderer = GetComponent<LineRenderer>();
            _springJoint2D = GetComponent<SpringJoint2D>();
        }

        private void Start() {
            _lineRenderer.startWidth = 0.2f;
            _lineRenderer.endWidth = 0.2f;
            _lineRenderer.enabled = false;
            _springJoint2D.enabled = false;
        }

        private void Update() {
            HandleGrapplingHook();
        }

        // called in GrappleNode.cs upon OnPointerDown event
        public void SelectNode(GrappleNode node) {
            SelectedNodeRb = node.GetComponent<Rigidbody2D>();
        }

        // called in GrappleNode.cs upon OnPointerUp event
        public void DeselectNode() {
            SelectedNodeRb = null;
        }

        private void HandleGrapplingHook() {
            if (SelectedNodeRb) {
                _lineRenderer.enabled = true;
                _springJoint2D.enabled = true;
                _springJoint2D.connectedBody = SelectedNodeRb;

                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, SelectedNodeRb.transform.position);
            } else {
                _lineRenderer.enabled = false;
                _springJoint2D.enabled = false;
            }
        }
    }
}