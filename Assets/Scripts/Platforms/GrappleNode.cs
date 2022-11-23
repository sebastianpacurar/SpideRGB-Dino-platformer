using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platforms {
    public class GrappleNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        private GameObject _dino;
        private GrappleLogic _dinoGrappleScript;
        private CollisionLogic _collisionLogic;

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _dinoGrappleScript = _dino.GetComponent<GrappleLogic>();
            _collisionLogic = transform.parent.gameObject.GetComponent<CollisionLogic>();
        }

        // if difficulty set to hard, and the target platform mismatches the dino color, destroy the platform
        public void OnPointerDown(PointerEventData eventData) {
            if (!transform.parent.CompareTag(_dino.name.Split(" ")[0]) && GameManager.Instance.GameDifficulty.Equals((int)Difficulty.Impossible)) {
                _collisionLogic.DestroyPlatform();
            } else {
                _dinoGrappleScript.SelectNode(this);
            }
        }

        public void OnPointerUp(PointerEventData eventData) {
            _dinoGrappleScript.DeselectNode();
        }
    }
}