using UnityEngine;

namespace Player {
    public class SwapAnimationEvent : MonoBehaviour {
        private SpriteRenderer _dino;
        private Animator _animator;
        private static readonly int Active = Animator.StringToHash("active");

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            _dino = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        }

        // disable parent sprite when swap animation is triggered
        private void ActivateSwap() {
            _dino.enabled = false;
        }

        // reenable parent sprite midway
        private void ReactivateDinoSprite() {
            _dino.enabled = true;
        }

        // set swap animation back to idle 
        private void DeactivateSwap() {
            _animator.SetBool(Active, false);
        }
    }
}