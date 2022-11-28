using System.Collections;
using Cinemachine;
using UnityEngine;

namespace PowerUps {
    public class OneUpManager : MonoBehaviour {
        [SerializeField] private GameObject powerUp;
        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;

        private Camera _mainCam;
        private CinemachineVirtualCamera _cm;
        private Vector2 _screenBounds;

        private float _spriteWidth;
        private float _spawnTime;

        private void Awake() {
            _mainCam = Camera.main;
        }

        private void Start() {
            _screenBounds = _mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCam.transform.position.z));
            _cm = GameObject.FindGameObjectWithTag("CM2D").GetComponent<CinemachineVirtualCamera>();
            _spriteWidth = powerUp.GetComponent<SpriteRenderer>().bounds.extents.x;

            // set spawn rate based on difficulty
            _spawnTime = GameManager.Instance.GameDifficulty switch {
                (int)Difficulty.Sidekick => 5f,
                (int)Difficulty.Hero => 5f,
                (int)Difficulty.Superhero => 4f,
                (int)Difficulty.Epichero => 3f,
                _ => 1f,
            };

            StartCoroutine(SpawnOneUps());
        }

        private IEnumerator SpawnOneUps() {
            while (true) {
                yield return new WaitForSeconds(_spawnTime);

                var strawberry = Instantiate(powerUp, transform);
                strawberry.name = $"{name} - {System.Guid.NewGuid().ToString()}";

                var cmTransform = _cm.transform.position;
                var y = _screenBounds.y + cmTransform.y;

                var rightPos = rightWall.localPosition;
                var leftPos = leftWall.localPosition;
                var finalPos = new Vector3(Random.Range(leftPos.x, rightPos.x), Random.Range(y, -y), 0);

                finalPos.x = Mathf.Clamp(finalPos.x, leftPos.x + _spriteWidth, rightPos.x - _spriteWidth); // clamp x to X-axis cam view 
                finalPos.y = Mathf.Clamp(finalPos.y, y - _screenBounds.y / 2, y + _screenBounds.y / 2); // clamp y to 25% below and 25% above the top edge of the camera

                // Set boundary for the highest point platforms can spawn on the Y-axis (prevent them from spawning outside of the game area)
                if (finalPos.y > 190f) {
                    finalPos.y = Random.Range(minInclusive: 180.0f, maxInclusive: 185.0f);
                }

                powerUp.transform.position = finalPos;
            }
        }
    }
}