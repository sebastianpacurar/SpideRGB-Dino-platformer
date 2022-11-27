using UnityEngine;
using UnityEngine.UI;

namespace Player.HelperUi {
    public class HpHelper : MonoBehaviour {
        private Camera _mainCam;
        private Image _img;
        private LifeManager _lifeManager;

        // used to swap between red and green hp bar sprite image
        [SerializeField] private Sprite[] sprites;

        [SerializeField] private Canvas parentCanvas;

        private void Awake() {
            _mainCam = Camera.main;
            _img = GetComponent<Image>();
        }

        private void Start() {
            parentCanvas.renderMode = RenderMode.WorldSpace;
            parentCanvas.worldCamera = _mainCam;
            _lifeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        private void Update() {
            FillHpBar();
        }

        private void FillHpBar() {
            // set the corresponding progress bar sprite (0=green, 1=red)
            switch (_lifeManager.CurrentHp) {
                case >= 3:
                    _img.sprite = sprites[0];
                    break;
                case <= 2:
                    _img.sprite = sprites[1];
                    break;
            }

            _img.fillAmount = _lifeManager.CurrentHp / (float)LifeManager.MaxHp;
        }
    }
}