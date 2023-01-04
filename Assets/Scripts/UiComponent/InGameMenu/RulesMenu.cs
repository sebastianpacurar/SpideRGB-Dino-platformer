using UnityEngine;

namespace UiComponent.InGameMenu {
    public class RulesMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;

        public void Open() {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        public void Close() {
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }
}