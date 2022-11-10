using UnityEngine;

namespace Platforms {
    public class ParticleBurst : MonoBehaviour {
        private ParticleSystem _ps;
        private ParticleSystem.EmissionModule _emissionModule;

        private SpriteRenderer _sr;
        private CapsuleCollider2D _capsuleCollider2d;

        private void Awake() {
            _sr = GetComponent<SpriteRenderer>();
            _capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        }

        private void Start() {
            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            _emissionModule = _ps.emission;
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                var dino = col.gameObject;
                if (dino.name.Split(" ")[0].Equals(gameObject.tag)) {
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
            Destroy(_sr);
            Destroy(_capsuleCollider2d);
            _emissionModule.enabled = true;

            _ps.Play();
            Invoke(nameof(DestroyObj), _ps.main.duration);
        }

        private void DestroyObj() {
            Destroy(gameObject);
        }
    }
}