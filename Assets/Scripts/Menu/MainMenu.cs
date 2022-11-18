using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    public class MainMenu : MonoBehaviour {
        public void StartAdventurerMode() {
            SceneManager.LoadScene("LevelOne");
        }

        public void StartSpiderDinoMode() {
            SceneManager.LoadScene("SpiderDino");
        }
    }
}