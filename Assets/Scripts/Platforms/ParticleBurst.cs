using UnityEngine;

namespace Platforms {
    public class ParticleBurst : MonoBehaviour {
        private ParticleSystem _ps;
        private SpriteRenderer _sr;
        private CapsuleCollider2D _bc2d;
        private string _platformType;

        private void Awake() {
            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            _sr = GetComponent<SpriteRenderer>();
            _bc2d = GetComponent<CapsuleCollider2D>();
            _platformType = name.Split(" ")[0];
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                var dino = col.gameObject;
                if (dino.name.Split(" ")[0] == _platformType) {
                    dino.transform.SetParent(transform);
                } else {
                    DestroyPlatform();
                }
            }
        }

        private void OnCollisionExit2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                col.gameObject.transform.SetParent(null);
            }
        }

        // used here and in SwitchDino.cs
        public void DestroyPlatform() {
            var emissionModule = _ps.emission;

            Destroy(_sr);
            Destroy(_bc2d);
            emissionModule.enabled = true;

            _ps.Play();
            Invoke(nameof(DestroyObj), _ps.main.duration);
        }

        private void DestroyObj() {
            Destroy(gameObject);
        }
    }
}