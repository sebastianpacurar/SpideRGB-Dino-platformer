using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UiComponent {
    public class MainMenu : MonoBehaviour {
        public void StartGameScene() {
            // set the level difficulty based on the Button's game object name
            GameManager.Instance.GameDifficulty = EventSystem.current.currentSelectedGameObject.name switch {
                "Sidekick" => (int)Difficulty.Sidekick,
                "Hero" => (int)Difficulty.Hero,
                "Superhero" => (int)Difficulty.Superhero,
                _ => (int)Difficulty.Sidekick,
            };

            SceneManager.LoadScene("GamePlay");
        }
    }
}