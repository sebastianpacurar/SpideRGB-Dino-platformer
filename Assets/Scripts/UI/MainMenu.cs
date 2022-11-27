using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class MainMenu : MonoBehaviour {
        public void StartSidekickScene() {
            SceneManager.LoadScene("Sidekick");
        }

        public void StartHeroScene() {
            SceneManager.LoadScene("Hero");
        }

        public void StartSuperheroScene() {
            SceneManager.LoadScene("Superhero");
        }

        public void StartEpicheroScene() {
            SceneManager.LoadScene("Epichero");
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}