using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UiComponent.InGameMenu {
    public class FailedMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        private LifeManager _dinoLifeScript;
        private ProgressDetails _progressDetails;
        [SerializeField] private TextMeshProUGUI destroyedPlatformsTxt;
        [SerializeField] private TextMeshProUGUI timeTxt;

        public bool Active { get; private set; }

        private void Start() {
            _dinoLifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
            _progressDetails = transform.Find("Dino Progress UI").GetComponent<ProgressDetails>();
        }

        public void Retry() {
            _dinoLifeScript.Lives = 5; // used only to avoid having Lives = 0 right when the next Update() gets called

            Active = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update() {
            if (_dinoLifeScript.Lives != 0 || Active) return;
            destroyedPlatformsTxt.text = $"Destroyed Platforms: {_progressDetails.DestroyedPlatformsCount}";
            timeTxt.text = _progressDetails.FormattedTime;
            Time.timeScale = 0;
            Active = true;
            panel.SetActive(true);
        }
    }
}