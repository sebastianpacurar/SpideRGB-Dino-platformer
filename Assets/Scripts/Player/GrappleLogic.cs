using Platforms;
using UnityEngine;

namespace Player {
    public class GrappleLogic : MonoBehaviour {
        private LineRenderer _lineRenderer;
        private DistanceJoint2D _distanceJoint2D;

        // the reference to "Grapple Node" game object
        private Rigidbody2D _selectedNodeRb;

        private void Awake() {
            _lineRenderer = GetComponent<LineRenderer>();
            _distanceJoint2D = GetComponent<DistanceJoint2D>();
        }

        private void Start() {
            _lineRenderer.startWidth = 0.2f;
            _lineRenderer.endWidth = 0.2f;
            _lineRenderer.enabled = false;
            _distanceJoint2D.enabled = false;
        }

        private void Update() {
            HandleGrapplingHook();
        }

        // called in GrappleNode.cs upon OnPointerDown event
        public void SelectNode(GrappleNode node) {
            _selectedNodeRb = node.GetComponent<Rigidbody2D>();
        }

        // called in GrappleNode.cs upon OnPointerUp event
        public void DeselectNode() {
            _selectedNodeRb = null;
        }

        private void HandleGrapplingHook() {
            if (_selectedNodeRb) {
                _lineRenderer.enabled = true;
                _distanceJoint2D.enabled = true;
                _distanceJoint2D.connectedBody = _selectedNodeRb;

                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, _selectedNodeRb.transform.position);
            } else {
                _lineRenderer.enabled = false;
                _distanceJoint2D.enabled = false;
            }
        }
    }
}