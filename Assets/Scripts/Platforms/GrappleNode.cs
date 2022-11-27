using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platforms {
    public class GrappleNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        private GameObject _dino;
        private GrappleLogic _dinoGrappleScript;

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _dinoGrappleScript = _dino.GetComponent<GrappleLogic>();
        }

        // if difficulty set to hard, and the target platform mismatches the dino color, destroy the platform
        public void OnPointerDown(PointerEventData eventData) {
            _dinoGrappleScript.SelectNode(this);
        }

        public void OnPointerUp(PointerEventData eventData) {
            _dinoGrappleScript.DeselectNode();
        }
    }
}