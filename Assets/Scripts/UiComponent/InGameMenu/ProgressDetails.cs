using System;
using TMPro;
using UnityEngine;

namespace UiComponent.InGameMenu {
    public class ProgressDetails : MonoBehaviour {
        public int DestroyedPlatformsCount { get; set; }
        [SerializeField] private TextMeshProUGUI platformsTxt;

        private float _currTime;
        public string FormattedTime { get; private set; } // used in Success/Failed/Pause Menus
        [SerializeField] private TextMeshProUGUI timeTxt;


        private void Update() {
            UpdateTimer();
            platformsTxt.text = $"Destroyed Platforms: {DestroyedPlatformsCount}";
        }

        private void UpdateTimer() {
            _currTime = _currTime += Time.deltaTime;
            var min = MathF.Floor(_currTime / 60);
            var sec = MathF.Floor(_currTime % 60);
            FormattedTime = $"Time: {min:00}:{sec:00}";
            timeTxt.text = FormattedTime;
        }
    }
}