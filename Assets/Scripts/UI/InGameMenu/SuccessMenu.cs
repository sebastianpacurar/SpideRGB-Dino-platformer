using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.InGameMenu {
    public class SuccessMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI destroyedPlatformsTxt;
        [SerializeField] private TextMeshProUGUI timeTxt;
        private ProgressDetails _progressDetails;

        public bool Active { get; set; }

        private void Start() {
            _progressDetails = transform.Find("Dino Progress UI").GetComponent<ProgressDetails>();
        }

        public void Retry() {
            Time.timeScale = 1;
            Active = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update() {
            if (!Active) return;
            destroyedPlatformsTxt.text = $"Destroyed Platforms: {_progressDetails.DestroyedPlatformsCount}";
            timeTxt.text = _progressDetails.FormattedTime;
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
}