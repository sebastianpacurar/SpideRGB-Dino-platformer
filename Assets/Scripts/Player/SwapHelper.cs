using Menu.InGameMenu.SwapCanvas;
using TMPro;
using UnityEngine;

namespace Player {
    public class SwapHelper : MonoBehaviour {
        private SwitchTop _switchTopUiScript;
        private TextMeshProUGUI _left;
        private TextMeshProUGUI _right;

        private void Start() {
            _switchTopUiScript = GameObject.FindGameObjectWithTag("TopDinoContainer").GetComponent<SwitchTop>();
            _left = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _right = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        // update letter colors based on the SwapDino UI Top section's updated colors
        private void Update() {
            _left.color = _switchTopUiScript.GetLeftActiveColor() switch {
                "Red" => MyColor.Red,
                "Green" => MyColor.Green,
                "Blue" => MyColor.Blue,
                _ => MyColor.White
            };
            _right.color = _switchTopUiScript.GetRightActiveColor() switch {
                "Red" => MyColor.Red,
                "Green" => MyColor.Green,
                "Blue" => MyColor.Blue,
                _ => MyColor.White
            };
        }
    }
}