using TMPro;
using UnityEngine;

namespace Player.HelperUi {
    public class LifeHelper : MonoBehaviour {
        private LifeManager _lifeManager;
        private TextMeshProUGUI _lifeCounter;

        private void Awake() {
            _lifeCounter = GetComponent<TextMeshProUGUI>();
        }

        private void Start() {
            _lifeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        private void Update() {
            _lifeCounter.text = $"x {_lifeManager.Lives}";
        }
    }
}