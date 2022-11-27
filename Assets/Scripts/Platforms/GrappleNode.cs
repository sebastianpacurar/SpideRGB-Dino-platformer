using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platforms {
    public class GrappleNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        private GameObject _dino;
        private GrappleLogic _dinoGrappleScript;
        
        [SerializeField] private AudioClip[] grappleThrowSfxClips;
        private AudioSource _grappleThrowSfx;
        
        private void Awake() {
            _grappleThrowSfx = GetComponent<AudioSource>();
        }
        
        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _dinoGrappleScript = _dino.GetComponent<GrappleLogic>();
        }

        // if difficulty set to hard, and the target platform mismatches the dino color, destroy the platform
        public void OnPointerDown(PointerEventData eventData) {
            _grappleThrowSfx.clip = grappleThrowSfxClips[Random.Range(0, grappleThrowSfxClips.Length)];
            _grappleThrowSfx.Play();
            _dinoGrappleScript.SelectNode(this);
        }

        public void OnPointerUp(PointerEventData eventData) {
            _dinoGrappleScript.DeselectNode();
        }
    }
}