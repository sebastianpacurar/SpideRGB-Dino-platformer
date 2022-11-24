using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.InGameMenu {
    public class Distance : MonoBehaviour {
        private GameObject _dino;
        private GameObject _endGameBounds;
        private Image _img;
        private TextMeshProUGUI _distanceVal;

        // hardcoded since it's the point where dino is grounded on the grid, and not on 0, on the center of the screen
        private readonly float _dinoOffsetY = 6.475389f;

        private void Awake() {
            _img = GetComponent<Image>();
        }

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
            _endGameBounds = GameObject.FindGameObjectWithTag("EndGameBounds");
            _distanceVal = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            FillDistanceBAr();
        }

        private void FillDistanceBAr() {
            var max = _endGameBounds.transform.position.y - _dinoOffsetY;
            var dinoLocation = _dino.transform.position.y + _dinoOffsetY;
            var fillVal = dinoLocation / max;

            // second condition is due to minor offset above the 100% limit
            fillVal = fillVal switch {
                < 0 => 0,
                > 0.99f => 1,
                _ => fillVal
            };

            _img.fillAmount = fillVal;
            _distanceVal.text = $"{fillVal:0%}";
        }
    }
}