using System;
using TMPro;
using UnityEngine;

namespace Menu.InGameMenu {
    public class ProgressDetails : MonoBehaviour {
        public int DestroyedPlatformsCount { get; set; }
        private TextMeshProUGUI _platformsText;

        private float _currTime;
        private TextMeshProUGUI _timeText;

        private void Start() {
            _platformsText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _timeText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            UpdateTimer();
            _platformsText.text = $"Destroyed Platforms: {DestroyedPlatformsCount}";
        }

        private void UpdateTimer() {
            _currTime = _currTime += Time.deltaTime;
            var min = MathF.Floor(_currTime / 60);
            var sec = MathF.Floor(_currTime % 60);

            _timeText.text = $"Time: {min:00}:{sec:00}";
        }
    }
}