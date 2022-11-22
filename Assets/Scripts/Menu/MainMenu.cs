using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    public class MainMenu : MonoBehaviour {
        public void StartEasyDifficulty() {
            SceneManager.LoadScene("Easy");
        }

        public void StartHardDifficulty() {
            SceneManager.LoadScene("Hard");
        }
    }
}