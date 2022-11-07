using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class SwitchDino : MonoBehaviour {
        public string DinoType => _dinoType;

        // defaults to Green
        private string _dinoType = Rgb.Green.ToString();

        [SerializeField] private AnimatorOverrideController[] overrideControllers;
        private Animator _animator;
        private PlayerControls _playerControls;
        private ParticleBurst _parentScript;

        private void Awake() {
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
        }

        private void SetDino(string changeTo) {
            var parent = gameObject.transform.parent;

            foreach (var controller in overrideControllers) {
                var controllerName = controller.name.Split("-");

                if (controllerName[0].Equals(_dinoType) && controllerName[1].Equals(changeTo)) {
                    _animator.runtimeAnimatorController = controller;
                    name = $"{changeTo} Dino";

                    _dinoType = changeTo;
                    break;
                }
            }

            // destroy the platform if dino color doesn't match the platform tag when swapping while grounded 
            if (parent) {
                if (!parent.CompareTag(_dinoType)) {
                    _parentScript = parent.GetComponent<ParticleBurst>();
                    _parentScript.DestroyPlatform();
                }
            }
        }

        private void GetRed(InputAction.CallbackContext ctx) {
            SetDino(Rgb.Red.ToString());
        }

        private void GetGreen(InputAction.CallbackContext ctx) {
            SetDino(Rgb.Green.ToString());
        }

        private void GetBlue(InputAction.CallbackContext ctx) {
            SetDino(Rgb.Blue.ToString());
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