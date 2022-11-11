using Player;
using UnityEngine;

namespace Platforms {
    public class GrappleValidator : MonoBehaviour {
        private GameObject _grappleNodeObject;
        private GrappleLogic _dinoGrappleScript;

        private void Start() {
            _dinoGrappleScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GrappleLogic>();
            _grappleNodeObject = transform.GetChild(1).gameObject;
        }

        private void OnTriggerStay2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                _grappleNodeObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                if (_dinoGrappleScript.SelectedNodeRb) {
                    _dinoGrappleScript.DeselectNode();
                }
            }

            _grappleNodeObject.SetActive(false);
        }
    }
}