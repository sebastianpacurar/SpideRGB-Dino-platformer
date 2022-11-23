using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.InGameMenu {
    public class SuccessMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;

        public bool Active { get; set; }

        public void Retry() {
            Time.timeScale = 1;
            Active = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update() {
            if (!Active) return;
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
}