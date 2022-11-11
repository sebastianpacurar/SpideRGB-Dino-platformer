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

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                _grappleNodeObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                // when the dino swings over (above) the platform, then deselect the node before disabling the object
                // prevent deselection in case another platform exits the area
                if (_dinoGrappleScript.SelectedPlatformName.Equals(name)) {
                    _dinoGrappleScript.DeselectNode();
                }

                _grappleNodeObject.SetActive(false);
            }
        }
    }
}