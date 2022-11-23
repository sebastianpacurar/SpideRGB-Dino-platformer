using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.InGameMenu {
    public class FailedMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        private LifeManager _dinoLifeScript;

        public bool Active { get; private set; }

        private void Start() {
            _dinoLifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        public void Retry() {
            // the below specific line is used only to avoid having Lives = 0 right when the next Update() gets called
            _dinoLifeScript.Lives = 5;

            Active = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update() {
            if (_dinoLifeScript.Lives != 0 || Active) return;
            Time.timeScale = 0;
            Active = true;
            panel.SetActive(true);
        }
    }
}