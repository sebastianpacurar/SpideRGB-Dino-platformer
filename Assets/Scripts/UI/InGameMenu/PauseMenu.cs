using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UI.InGameMenu {
    public class PauseMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        private PlayerControls _controls;
        private FailedMenu _failedMenu;
        private SuccessMenu _successMenu;
        private ControlsMenu _controlsMenu;
        private RulesMenu _rulesMenu;
        private ProgressDetails _progressDetails;
        [SerializeField] private TextMeshProUGUI destroyedPlatformsTxt;
        [SerializeField] private TextMeshProUGUI timeTxt;

        private bool _isPaused;

        private void Awake() {
            _controls = new PlayerControls();
            _failedMenu = GetComponent<FailedMenu>();
            _successMenu = GetComponent<SuccessMenu>();
            _controlsMenu = GetComponent<ControlsMenu>();
            _rulesMenu = GetComponent<RulesMenu>();
        }

        private void Start() {
            _progressDetails = transform.Find("Dino Progress UI").GetComponent<ProgressDetails>();
        }

        private void Update() {
            destroyedPlatformsTxt.text = $"Destroyed Platforms: {_progressDetails.DestroyedPlatformsCount}";
            timeTxt.text = _progressDetails.FormattedTime;
        }

        private void ToggleMenu(InputAction.CallbackContext ctx) {
            if (_failedMenu.Active || _successMenu.Active || _controlsMenu.Active || _rulesMenu.Active) return;
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

        // used as unity event for the X icon - close button of PauseMenu
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