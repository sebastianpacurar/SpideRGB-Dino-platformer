using Player;
using TMPro;
using UnityEngine;

namespace UiComponent.InGameMenu {
    public class DinoLives : MonoBehaviour {
        private LifeManager _dinoLifeScript;

        private TextMeshProUGUI _lifeVal;

        private void Awake() {
            _lifeVal = GetComponent<TextMeshProUGUI>();
        }

        private void Start() {
            _dinoLifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        private void Update() {
            _lifeVal.text = $"x {_dinoLifeScript.Lives}";
        }
    }
}