using UnityEngine;

namespace UI.InGameMenu {
    public class CanvasAttachCam : MonoBehaviour {
        private Camera _mainCam;
        private Canvas _canvas;

        private void Awake() {
            _mainCam = Camera.main;
            _canvas = GetComponent<Canvas>();
        }

        private void Start() {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = _mainCam;
        }
    }
}