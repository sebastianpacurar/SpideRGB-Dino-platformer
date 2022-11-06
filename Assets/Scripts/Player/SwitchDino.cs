using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class SwitchDino : MonoBehaviour {
        [SerializeField] private AnimatorOverrideController[] overrideControllers;
        private Animator _animator;
        private PlayerControls _playerControls;
        private string _dinoType = "Green";

        private void Awake() {
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
        }

        private void SetDino(string changeTo) {
            foreach (var controller in overrideControllers) {
                var controllerName = controller.name.Split("-");

                if (controllerName[0].Equals(_dinoType) && controllerName[1].Equals(changeTo)) {
                    _animator.runtimeAnimatorController = controller;
                    name = $"{changeTo} Dino";

                    _dinoType = changeTo;
                    break;
                }
            }
        }

        private void GetRed(InputAction.CallbackContext ctx) {
            SetDino("Red");
        }

        private void GetGreen(InputAction.CallbackContext ctx) {
            SetDino("Green");
        }

        private void GetBlue(InputAction.CallbackContext ctx) {
            SetDino("Blue");
        }

        private void OnEnable() {
            _playerControls.Dino.Red.Enable();
            _playerControls.Dino.Green.Enable();
            _playerControls.Dino.Blue.Enable();
            _playerControls.Dino.Blue.performed += GetBlue;
            _playerControls.Dino.Red.performed += GetRed;
            _playerControls.Dino.Green.performed += GetGreen;
        }

        private void OnDisable() {
            _playerControls.Dino.Red.performed -= GetRed;
            _playerControls.Dino.Green.performed -= GetGreen;
            _playerControls.Dino.Blue.performed -= GetBlue;
            _playerControls.Dino.Blue.Disable();
            _playerControls.Dino.Red.Disable();
            _playerControls.Dino.Green.Disable();
        }
    }
}