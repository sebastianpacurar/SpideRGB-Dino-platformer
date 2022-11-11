using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platforms {
    public class GrappleNode : MonoBehaviour, IPointerDownHandler {
        private GameObject _dino;
        private GrappleLogic _dinoGrappleScript;

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _dinoGrappleScript = _dino.GetComponent<GrappleLogic>();
        }

        public void OnPointerDown(PointerEventData eventData) {
            _dinoGrappleScript.SelectNode(this);
        }

        // public void OnPointerUp(PointerEventData eventData) {
        //     _dinoGrappleScript.DeselectNode();
        // }
    }
}