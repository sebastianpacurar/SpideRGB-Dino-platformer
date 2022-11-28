using UiComponent.InGameMenu;
using UnityEngine;

namespace Player {
    public class LevelFinishValidator : MonoBehaviour {
        private SuccessMenu _successMenu;

        private void Start() {
            _successMenu = GameObject.FindGameObjectWithTag("InGameUi").GetComponent<SuccessMenu>();
        }

        // this class is simply used to trigger the SuccessMEnu upon trigger enter
        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("EndGameBounds")) {
                _successMenu.Active = true;
            }
        }
    }
}