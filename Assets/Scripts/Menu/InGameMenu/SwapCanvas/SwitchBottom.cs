using UnityEngine;

namespace Menu.InGameMenu.SwapCanvas {
    public class SwitchBottom : MonoBehaviour {
        [SerializeField] private GameObject[] leftArrows, rightArrows;

        private SwitchTop _switchTopUiScript;

        private void Start() {
            _switchTopUiScript = GameObject.FindGameObjectWithTag("TopDinoContainer").GetComponent<SwitchTop>();
        }

        public void UpdateArrows() {
            foreach (var obj in leftArrows) {
                obj.SetActive(obj.CompareTag(_switchTopUiScript.GetLeftActiveColor()));
            }

            foreach (var obj in rightArrows) {
                obj.SetActive(obj.CompareTag(_switchTopUiScript.GetRightActiveColor()));
            }
        }
    }
}