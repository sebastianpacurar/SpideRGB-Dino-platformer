using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Platforms {
    public class GrappleNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        private GameObject _dino;
        private GrappleLogic _dinoGrappleScript;

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _dinoGrappleScript = _dino.GetComponent<GrappleLogic>();
        }

        public void OnPointerDown(PointerEventData eventData) {
            _dinoGrappleScript.SelectNode(this);
        }

        public void OnPointerUp(PointerEventData eventData) {
            // SpiderDino is not forced to hold LMB to hold grapple attached
            if (SceneManager.GetActiveScene().name.Equals("SpiderDino")) return;

            _dinoGrappleScript.DeselectNode();
        }
    }
}