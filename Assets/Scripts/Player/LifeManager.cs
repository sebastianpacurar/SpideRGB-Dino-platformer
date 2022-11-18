using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player {
    public class LifeManager : MonoBehaviour {
        public int Lives { get; private set; } = 5;
        private HpManager _dinoHpScript;

        private void Start() {
            _dinoHpScript = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpManager>();
        }

        private void Update() {
            HandleGameOverScreen();
            HandleLives();
        }

        private void HandleGameOverScreen() {
            if (Lives == 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void HandleLives() {
            if (_dinoHpScript.CurrentHp > 0) return;
            Lives -= 1;
            _dinoHpScript.CurrentHp = _dinoHpScript.MaxHp;
        }
    }
}