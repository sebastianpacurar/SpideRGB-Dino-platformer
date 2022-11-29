using Player;
using UiComponent.InGameMenu;
using UnityEngine;

namespace Platforms {
    public class CollisionLogic : MonoBehaviour {
        private ParticleSystem _ps;
        private ParticleSystem.EmissionModule _emissionModule;

        private SpriteRenderer _sr;
        private CapsuleCollider2D _capsuleCollider2d;
        private GameObject _container;
        private LifeManager _lifeManager;
        private DinoController _controller;
        private ProgressDetails _progressDetails;

        [SerializeField] private AudioClip[] destroyedSfxClips;
        private AudioSource _destroyedSfx;

        private void Awake() {
            _sr = GetComponent<SpriteRenderer>();
            _capsuleCollider2d = GetComponent<CapsuleCollider2D>();
            _destroyedSfx = GetComponent<AudioSource>();
        }

        private void Start() {
            _container = transform.parent.gameObject;

            var player = GameObject.FindGameObjectWithTag("Player");
            _lifeManager = player.GetComponent<LifeManager>();
            _controller = player.GetComponent<DinoController>();

            _progressDetails = GameObject.FindGameObjectWithTag("InGameUi").transform.Find("Dino Progress UI").GetComponent<ProgressDetails>();
            _ps = transform.Find("Particle System").GetComponent<ParticleSystem>();
            _emissionModule = _ps.emission;
            AudioListener.volume = 0.5f;
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Player")) {
                var dino = col.gameObject;
                if (dino.name.Split(" ")[0].Equals(gameObject.tag)) {
                    dino.transform.SetParent(transform);
                    MyColor.SetAlphaKey(_sr, 1f);
                } else {
                    // activate Dino Hit Animation
                    _controller.IsHit = true;

                    // decrease Hp with 1 unit
                    _lifeManager.CurrentHp -= 1;

                    // increase counter for Destroyed Platforms
                    _progressDetails.DestroyedPlatformsCount += 1;

                    // Destroy current platform and its container
                    DestroyPlatform();
                }
            } else if (col.gameObject.transform.parent.gameObject.CompareTag("Platform")) {
                DestroyPlatform();
            }
        }

        private void OnCollisionExit2D(Collision2D col) {
            if (!col.gameObject.CompareTag("Player")) return;
            col.gameObject.transform.SetParent(null);
            MyColor.SetAlphaKey(_sr, 0.5f);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Edge")) {
                DestroyPlatform();
            }
        }

        // used here and in SwitchDino.cs
        public void DestroyPlatform() {
            _destroyedSfx.clip = destroyedSfxClips[Random.Range(0, destroyedSfxClips.Length)];
            _destroyedSfx.Play();

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