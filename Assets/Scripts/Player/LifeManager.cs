using UiComponent.InGameMenu;
using UnityEngine;

namespace Player {
    public class LifeManager : MonoBehaviour {
        public int Lives { get; set; } = 5;
        public int CurrentHp { get; set; } = 5;
        public static int MaxHp => 5;
        private Animator _animator;
        private FailedMenu _failedMenu;
        private Rigidbody2D _rb;
        private CapsuleCollider2D _capsuleCollider2D;
        private static readonly int Death = Animator.StringToHash("death");

        private void Awake() {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Start() {
            _failedMenu = GameObject.FindGameObjectWithTag("InGameUi").GetComponent<FailedMenu>();
        }

        private void Update() {
            HandleLives();
        }

        private void HandleLives() {
            if (CurrentHp > 0) return;
            Lives -= 1;
            CurrentHp = MaxHp;

            if (Lives != 0) return;
            _rb.bodyType = RigidbodyType2D.Static;
            _capsuleCollider2D.enabled = false;
            _animator.SetTrigger(Death);
        }

        // animation event to trigger Failed Menu
        private void SetFailedMenuToTrue() {
            _failedMenu.Active = true;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _capsuleCollider2D.enabled = true;
        }
    }
}