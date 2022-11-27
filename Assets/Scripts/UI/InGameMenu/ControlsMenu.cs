using UnityEngine;

namespace UI.InGameMenu {
    public class ControlsMenu : MonoBehaviour {
        [SerializeField] private GameObject panel;
        public bool Active { get; set; }

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