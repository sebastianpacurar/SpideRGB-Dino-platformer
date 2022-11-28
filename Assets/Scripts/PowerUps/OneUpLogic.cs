using Player;
using UnityEngine;

namespace PowerUps {
    public class OneUpLogic : MonoBehaviour {
        private Animator _animator;
        private Rigidbody2D _rb;
        private AudioSource _collectSfx;
        private LifeManager _lifeManager;

        private void Awake() {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _collectSfx = GetComponent<AudioSource>();
        }

        private void Start() {
            _lifeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                _lifeManager.Lives += 1;
                _collectSfx.Play();
                CollectSelf();
            }

            // set as child of platform
            if (col.gameObject.CompareTag("Platform")) {
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
            _animator.SetTrigger("collected");
        }

        // used as animation event
        private void DestroyObj() {
            Destroy(gameObject);
        }
    }
}