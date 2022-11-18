using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menu.InGameMenu {
    public class PauseMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        private PlayerControls _controls;

        private bool _isPaused;

        private void Awake() {
            _controls = new PlayerControls();
        }

        private void ToggleMenu(InputAction.CallbackContext ctx) {
            _isPaused = !_isPaused;
            if (_isPaused) {
                PauseMenuActivate();
            } else {
                PauseMenuDeactivate();
            }
        }

        private void PauseMenuActivate() {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        public void PauseMenuDeactivate() {
            Time.timeScale = 1;
            panel.SetActive(false);
        }

        public void GoToMainMenu() {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        private void OnEnable() {
            _controls.Menu.Esc.Enable();
            _controls.Menu.Esc.performed += ToggleMenu;
        }

        private void OnDisable() {
            _controls.Menu.Esc.performed -= ToggleMenu;
            _controls.Menu.Esc.Disable();
        }
    }
}