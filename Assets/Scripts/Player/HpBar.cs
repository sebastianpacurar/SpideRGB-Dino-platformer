using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class HpBar : MonoBehaviour {
        private Camera _mainCam;

        // used in ParticleBurst.cs to decrease by 1 when hit by wrong platform
        public int CurrentHp { get; set; } = 5;
        private int _maxHp = 5;

        // used to swap between red and green hp bar sprite image
        [SerializeField] private Sprite[] sprites;

        [SerializeField] private Canvas parentCanvas;
        private Image _image;

        private void Awake() {
            _mainCam = Camera.main;
            _image = GetComponent<Image>();
        }

        private void Start() {
            parentCanvas.renderMode = RenderMode.WorldSpace;
            parentCanvas.worldCamera = _mainCam;
        }

        private void Update() {
            FillHpBar();
        }

        private void FillHpBar() {
            // set the corresponding progress bar sprite (0=green, 1=red)
            switch (CurrentHp) {
                case >= 3:
                    _image.sprite = sprites[0];
                    break;
                case <= 2:
                    _image.sprite = sprites[1];
                    break;
            }

            _image.fillAmount = CurrentHp / (float)_maxHp;
        }
    }
}