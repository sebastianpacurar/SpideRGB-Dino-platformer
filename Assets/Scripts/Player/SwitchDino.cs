using Platforms;
using UiComponent.InGameMenu.SwapCanvas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class SwitchDino : MonoBehaviour {
        public string DinoType { get; private set; } = "Green";

        private Animator _swapAnimator;
        private ParticleSystem _ps;

        [SerializeField] private AnimatorOverrideController[] overrideControllers;
        [SerializeField] private AudioSource swapSfx;
        private Animator _animator;
        private PlayerControls _playerControls;
        private CollisionLogic _parentPlatform;
        private LineRenderer _lineRenderer;

        private SwitchTop _topUiContainer;
        private SwitchBottom _bottomUiContainer;

        private bool _btnCooldown;

        private void Awake() {
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start() {
            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            _topUiContainer = GameObject.FindGameObjectWithTag("TopDinoContainer").GetComponent<SwitchTop>();
            _bottomUiContainer = GameObject.FindGameObjectWithTag("BottomDinoContainer").GetComponent<SwitchBottom>();

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
                    _parentPlatform = parent.GetComponent<CollisionLogic>();
                    _parentPlatform.DestroyPlatform();
                }
            }

            SetGrappleLineColor();
        }

        // prevent spamming of Q and A keys
        private void ResetBtnCd() {
            _btnCooldown = false;
        }

        private void GetLeft(InputAction.CallbackContext ctx) {
            if (!_btnCooldown) {
                var leftActive = _topUiContainer.GetLeftActiveColor();
                UpdateDinoUiSwap(leftActive, "left");
                PerformSwap(leftActive);

                Invoke(nameof(ResetBtnCd), 0.5f);
                _btnCooldown = true;
            }
        }

        private void GetRight(InputAction.CallbackContext ctx) {
            if (!_btnCooldown) {
                var rightActive = _topUiContainer.GetRightActiveColor();
                UpdateDinoUiSwap(rightActive, "right");
                PerformSwap(rightActive);

                Invoke(nameof(ResetBtnCd), 0.5f);
                _btnCooldown = true;
            }
        }

        // swap the colors between the current and new color. update arrows to point towards the right color.
        private void UpdateDinoUiSwap(string newColor, string direction) {
            _topUiContainer.Swap(DinoType, newColor, direction);
            _bottomUiContainer.UpdateArrows();
        }

        private void PerformSwap(string color) {
            _swapAnimator.SetBool("active", true);
            SetDino(color);
            swapSfx.Play();
        }

        // set the correct Particle System start color
        private void SetParticleColorStart() {
            var mainModule = _ps.main;
            mainModule.startColor = DinoType switch {
                "Red" => MyColor.Red,
                "Green" => MyColor.Green,
                "Blue" => MyColor.Blue,
                _ => MyColor.White
            };
        }

        private void SetGrappleLineColor() {
            switch (DinoType) {
                case "Red":
                    _lineRenderer.startColor = MyColor.Red;
                    _lineRenderer.endColor = MyColor.Red;
                    break;
                case "Green":
                    _lineRenderer.startColor = MyColor.Green;
                    _lineRenderer.endColor = MyColor.Green;
                    break;
                case "Blue":
                    _lineRenderer.startColor = MyColor.Blue;
                    _lineRenderer.endColor = MyColor.Blue;
                    break;
                default:
                    _lineRenderer.startColor = MyColor.White;
                    _lineRenderer.endColor = MyColor.White;
                    break;
            }
        }

        private void OnEnable() {
            _playerControls.Menu.Left.Enable();
            _playerControls.Menu.Right.Enable();
            _playerControls.Menu.Left.performed += GetLeft;
            _playerControls.Menu.Right.performed += GetRight;
        }

        private void OnDisable() {
            _playerControls.Menu.Left.performed -= GetLeft;
            _playerControls.Menu.Right.performed -= GetRight;

            _playerControls.Menu.Left.Disable();
            _playerControls.Menu.Right.Disable();
        }
    }
}