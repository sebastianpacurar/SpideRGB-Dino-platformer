using Player;
using UnityEngine;

namespace PowerUps {
    public class OneUpLogic : MonoBehaviour {
        private Animator _animator;
        private Rigidbody2D _rb;
        private LifeManager _lifeManager;
        private static readonly int Collected = Animator.StringToHash("collected");

        private void Awake() {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _lifeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                _lifeManager.Lives += 1;
                CollectSelf();
            }

            // set as child of platform
            if (col.gameObject.name.EndsWith("Platform")) {
                transform.SetParent(col.gameObject.transform);
            }

            // destroy when reaches the land (tile ground)
            if (col.gameObject.CompareTag("Land")) {
                CollectSelf();
            }
        }

        // set power up parent to none when falling off
        private void OnCollisionExit2D(Collision2D col) {
            if (col.gameObject.name.Equals(transform.parent.name)) {
                transform.SetParent(null);
            }
        }

        private void CollectSelf() {
            _rb.bodyType = RigidbodyType2D.Static;
            _animator.SetTrigger(Collected);
        }

        // used as animation event
        private void DestroyObj() {
            Destroy(gameObject);
        }
    }
}