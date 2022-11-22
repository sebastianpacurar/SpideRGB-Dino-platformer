using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Platforms {
    public class CollisionLogic : MonoBehaviour {
        private ParticleSystem _ps;
        private ParticleSystem.EmissionModule _emissionModule;

        private SpriteRenderer _sr;
        private CapsuleCollider2D _capsuleCollider2d;
        private GameObject _container;
        private HpManager _dinoHpScript;
        private DinoController _dinoControllerScript;

        private void Awake() {
            _sr = GetComponent<SpriteRenderer>();
            _capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        }

        private void Start() {
            _container = transform.parent.gameObject;
            _dinoHpScript = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpManager>();
            _dinoControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<DinoController>();

            _ps = transform.GetChild(0).GetComponent<ParticleSystem>();
            _emissionModule = _ps.emission;
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                var dino = col.gameObject;
                if (dino.name.Split(" ")[0].Equals(gameObject.tag)) {
                    dino.transform.SetParent(transform);
                    _sr.color = _sr.color.WithAlpha(1f);
                } else {
                    // activate Hit Animation
                    _dinoControllerScript.IsHit = true;

                    // decrease Hp with 1 unit
                    _dinoHpScript.CurrentHp -= 1;

                    // Destroy current platform and its container
                    DestroyPlatform();
                }
            }

            if (col.gameObject.transform.parent.gameObject.CompareTag("Platform")) {
                DestroyPlatform();
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Edge")) {
                DestroyPlatform();
            }
        }

        private void OnCollisionExit2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                col.gameObject.transform.SetParent(null);
                _sr.color = _sr.color.WithAlpha(0.5f);
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

        // destroy the Platform Container object
        private void DestroyObj() {
            Destroy(gameObject);
            Destroy(_container);
        }
    }
}