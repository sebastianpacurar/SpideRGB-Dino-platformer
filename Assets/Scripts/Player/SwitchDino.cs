using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class SwitchDino : MonoBehaviour {
        // defaults to Green
        public string DinoType { get; private set; } = Rgb.Green.ToString();

        private Animator _swapAnimator;
        private ParticleSystem _ps;

        [SerializeField] private AnimatorOverrideController[] overrideControllers;
        private Animator _animator;
        private PlayerControls _playerControls;
        private ParticleBurst _parentPlatform;

        private void Awake() {
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();

            var swapObj = GameObject.FindGameObjectWithTag("Swap");
            _swapAnimator = swapObj.GetComponent<Animator>();
        }

        private void Update() {
            SetParticleColorStart();
        }

        private void SetDino(string color) {
            var parent = gameObject.transform.parent;

            foreach (var controller in overrideControllers) {
                var controllerName = controller.name.Split("-");

                // set the correct controller based on the assets names
                if (controllerName[0].Equals(DinoType) && controllerName[1].Equals(color)) {
                    _animator.runtimeAnimatorController = controller;

                    name = $"{color} Dino";
                    DinoType = color;
                    break;
                }
            }

            // destroy the platform if dino color doesn't match the platform tag when swapping while grounded 
            if (parent) {
                if (!parent.CompareTag(DinoType)) {
                    _parentPlatform = parent.GetComponent<ParticleBurst>();
                    _parentPlatform.DestroyPlatform();
                }
            }
        }

        private void GetRed(InputAction.CallbackContext ctx) {
            PerformSwap(Rgb.Red.ToString());
        }

        private void GetGreen(InputAction.CallbackContext ctx) {
            PerformSwap(Rgb.Green.ToString());
        }

        private void GetBlue(InputAction.CallbackContext ctx) {
            PerformSwap(Rgb.Blue.ToString());
        }

        // prevent from calling swap animation on the same dino type (color)
        private void PerformSwap(string color) {
            if (!DinoType.Equals(color)) {
                _swapAnimator.SetBool("active", true);
                SetDino(color);
            }
        }

        // set the correct Particle System start color
        private void SetParticleColorStart() {
            var mainModule = _ps.main;
            mainModule.startColor = DinoType switch {
                "Red" => new Color(1f, 0.5369426f, 0f, 1f),
                "Green" => new Color(0.333f, 0.603f, 0f, 1f),
                "Blue" => new Color(0f, 0.7545424f, 1, 1f),
                _ => mainModule.startColor
            };
        }

        private void OnEnable() {
            _playerControls.Menu.Red.Enable();
            _playerControls.Menu.Green.Enable();
            _playerControls.Menu.Blue.Enable();
            _playerControls.Menu.Blue.performed += GetBlue;
            _playerControls.Menu.Red.performed += GetRed;
            _playerControls.Menu.Green.performed += GetGreen;
        }

        private void OnDisable() {
            _playerControls.Menu.Red.performed -= GetRed;
            _playerControls.Menu.Green.performed -= GetGreen;
            _playerControls.Menu.Blue.performed -= GetBlue;
            _playerControls.Menu.Blue.Disable();
            _playerControls.Menu.Red.Disable();
            _playerControls.Menu.Green.Disable();
        }
    }
}