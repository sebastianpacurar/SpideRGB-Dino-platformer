using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu.InGameMenu {
    public class PauseMenu : MonoBehaviour {
        private PlayerControls _controls;
        private bool _isPaused;
        private GameObject _panel;

        private void Awake() {
            _controls = new PlayerControls();
        }

        private void Start() {
            _panel = GameObject.FindGameObjectWithTag("PauseMenu").gameObject;
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
            _panel.SetActive(true);
        }

        //TODO: used by Back button
        public void PauseMenuDeactivate() {
            Time.timeScale = 1;
            _panel.SetActive(false);
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