using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Platforms {
    public class GrappleValidator : MonoBehaviour {
        [SerializeField] private GameObject grappleNode;
        private GrappleLogic _dinoGrappleScript;
        private SpriteRenderer _sr;

        private void Awake() {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Start() {
            _dinoGrappleScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GrappleLogic>();
            MakeTransparent();
        }

        private void OnTriggerStay2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                Reveal();
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("GrappleArea")) {
                // when the dino swings over (above) the platform, then deselect the node before disabling the object
                // prevent deselection in case another platform exits the area
                if (_dinoGrappleScript.SelectedPlatformName.Equals(transform.parent.name)) {
                    _dinoGrappleScript.DeselectNode();
                }

                MakeTransparent();
            }
        }

        private void Reveal() {
            grappleNode.SetActive(true);
            _sr.color = _sr.color.WithAlpha(1f);
        }

        private void MakeTransparent() {
            grappleNode.SetActive(false);
            _sr.color = _sr.color.WithAlpha(0.5f);
        }
    }
}