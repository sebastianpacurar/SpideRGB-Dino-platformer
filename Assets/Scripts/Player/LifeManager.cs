using UnityEngine;

namespace Player {
    public class LifeManager : MonoBehaviour {
        public int Lives { get; set; } = 5;
        public int CurrentHp { get; set; } = 5;
        public static int MaxHp => 5;

        private void Update() {
            HandleLives();
        }

        private void HandleLives() {
            if (CurrentHp > 0) return;
            Lives -= 1;
            CurrentHp = MaxHp;
        }
    }
}