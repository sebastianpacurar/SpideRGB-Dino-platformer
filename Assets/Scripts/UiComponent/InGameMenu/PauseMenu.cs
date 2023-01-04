using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UiComponent.InGameMenu {
    public class PauseMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        private ProgressDetails _progressDetails;
        [SerializeField] private TextMeshProUGUI destroyedPlatformsTxt;
        [SerializeField] private TextMeshProUGUI timeTxt;
        private bool _isPaused;

        private void Start() {
            _progressDetails = transform.Find("Dino Progress UI").GetComponent<ProgressDetails>();
        }

        private void Update() {
            destroyedPlatformsTxt.text = $"Destroyed Platforms: {_progressDetails.DestroyedPlatformsCount}";
            timeTxt.text = _progressDetails.FormattedTime;
        }

        // used as unity event for the Pause Menu btn
        public void PauseMenuActivate() {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        // used as unity event for the X icon - close button of PauseMenu
        public void PauseMenuDeactivate() {
            Time.timeScale = 1;
            panel.SetActive(false);
        }

        // used for Retry btn
        public void Retry() {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // used for Main Menu btn
        public void GoToMainMenu() {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}