using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
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
    }
}