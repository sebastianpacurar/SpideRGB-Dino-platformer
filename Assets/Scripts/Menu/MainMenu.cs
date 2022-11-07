using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    public class MainMenu : MonoBehaviour {
        public void StartGame() {
            SceneManager.LoadScene("LevelOne");
        }
    }
}