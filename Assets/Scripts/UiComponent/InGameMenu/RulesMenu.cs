using UnityEngine;

namespace UiComponent.InGameMenu {
    public class RulesMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        public bool Active { get; private set; }

        public void Open() {
            Time.timeScale = 0;
            Active = true;
            panel.SetActive(true);
        }

        public void Close() {
            Time.timeScale = 1;
            Active = false;
            panel.SetActive(false);
        }
    }
}