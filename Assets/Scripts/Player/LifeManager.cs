using UnityEngine;

namespace Player {
    public class LifeManager : MonoBehaviour {
        public int Lives { get; set; } = 5;
        private HpManager _dinoHpScript;

        private void Start() {
            _dinoHpScript = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpManager>();
        }

        private void Update() {
            HandleLives();
        }

        private void HandleLives() {
            if (_dinoHpScript.CurrentHp > 0) return;
            Lives -= 1;
            _dinoHpScript.CurrentHp = HpManager.MaxHp;
        }
    }
}