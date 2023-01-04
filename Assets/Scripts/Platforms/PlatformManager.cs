using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Platforms {
    public class PlatformManager : MonoBehaviour {
        [SerializeField] private GameObject[] platforms;
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
            _spriteWidth = platforms[0].transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x;

            // set spawn rate based on difficulty
            _spawnTime = GameManager.Instance.GameDifficulty switch {
                (int)Difficulty.Sidekick => 0.75f,
                (int)Difficulty.Hero => 0.5f,
                (int)Difficulty.Superhero => 0.25f,
                _ => 1f,
            };

            StartCoroutine(SpawnPlatforms());
        }

        private IEnumerator SpawnPlatforms() {
            while (true) {
                yield return new WaitForSeconds(_spawnTime);
                Vector2 pointA; // used for hard and impossible
                Vector2 pointB; // used for hard and impossible

                var platform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform);
                platform.name = $"{name} - {System.Guid.NewGuid().ToString()}";

                var pos = platform.transform.position; // position of platform container
                platform.transform.localScale = new Vector3(1.75f, 1.75f, pos.z); // scale the platform container by 1.75

                switch (GameManager.Instance.GameDifficulty) {
                    case (int)Difficulty.Hero:
                        var distance = Random.Range(minInclusive: 5.0f, maxInclusive: 10.0f); // set a fixed distance for the points

                        // 0 is X-axis, 1 is Y-axis
                        if (Random.Range(0, 2).Equals(0)) {
                            pointA = new Vector2(-distance, pos.y);
                            pointB = new Vector2(distance, pos.y);
                        } else {
                            pointA = new Vector2(platform.transform.position.x, -distance);
                            pointB = new Vector2(pos.x, distance);
                        }

                        platform.transform.GetChild(1).transform.GetChild(0).transform.position = pointA;
                        platform.transform.GetChild(1).transform.GetChild(1).transform.position = pointB;
                        break;

                    case (int)Difficulty.Superhero:
                        platform.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true); // there are at least 3 patrol points and at most 4

                        // logic is Distance (rand float between 5 and 10 inclusive) divided by random float between 1 and 3
                        pointA = new Vector2(-Random.Range(minInclusive: 5.0f, maxInclusive: 10.0f) / Random.Range(minInclusive: 1f, maxInclusive: 3f), pos.y);
                        pointB = new Vector2(Random.Range(minInclusive: 5.0f, maxInclusive: 10.0f) / Random.Range(minInclusive: 1f, maxInclusive: 3f), pos.y);
                        var pointC = new Vector2(pos.x, -Random.Range(minInclusive: 5.0f, maxInclusive: 10.0f) / Random.Range(minInclusive: 1f, maxInclusive: 3f)); // using 3rd patrol point 

                        platform.transform.GetChild(1).transform.GetChild(0).transform.position = pointA;
                        platform.transform.GetChild(1).transform.GetChild(1).transform.position = pointB;
                        platform.transform.GetChild(1).transform.GetChild(2).transform.position = pointC;

                        // 1 means that there is a 4th patrol point
                        if (Random.Range(0, 1).Equals(1)) {
                            var pointD = new Vector2(platform.transform.position.x, Random.Range(minInclusive: 5.0f, maxInclusive: 10.0f) / Random.Range(minInclusive: 1f, maxInclusive: 3f)); // using 4th patrol point
                            platform.transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(true);
                            platform.transform.GetChild(1).transform.GetChild(3).transform.position = pointD;
                        }

                        break;
                }

                // generation of platforms location
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

                platform.transform.position = finalPos;
            }
        }
    }
}