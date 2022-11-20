using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Platforms {
    // this applies only to Spider Dino game mode
    public class PlatformManager : MonoBehaviour {
        [SerializeField] private GameObject[] platforms;
        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;

        private Camera _mainCam;
        private CinemachineVirtualCamera _cm;
        private Vector2 _screenBounds;

        private float _spriteWidth;

        private void Awake() {
            _mainCam = Camera.main;
        }

        private void Start() {
            _screenBounds = _mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCam.transform.position.z));
            _cm = GameObject.FindGameObjectWithTag("CM2D").GetComponent<CinemachineVirtualCamera>();
            _spriteWidth = platforms[0].transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x;

            StartCoroutine(SpawnPlatforms());
        }

        private IEnumerator SpawnPlatforms() {
            while (true) {
                yield return new WaitForSeconds(0.25f);

                var platform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform);
                platform.name = $"{name} - {System.Guid.NewGuid().ToString()}";

                // if random throws 0, then enable patrol points
                if (Random.Range(0, 2).Equals(0)) {
                    var distance = Random.Range(5, 11);

                    Vector2 pointA;
                    Vector2 pointB;

                    // 0 is X-axis, 1 is Y-axis
                    if (Random.Range(0, 2).Equals(0)) {
                        pointA = new Vector3(-distance, platform.transform.position.y);
                        pointB = new Vector3(distance, platform.transform.position.y);
                    } else {
                        pointA = new Vector3(platform.transform.position.x, -distance);
                        pointB = new Vector3(platform.transform.position.x, distance);
                    }

                    platform.transform.GetChild(1).transform.GetChild(0).transform.position = pointA;
                    platform.transform.GetChild(1).transform.GetChild(1).transform.position = pointB;
                }


                // generation of platforms location
                var cmTransform = _cm.transform.position;
                var y = _screenBounds.y + cmTransform.y;

                var rightPos = rightWall.localPosition;
                var leftPos = leftWall.localPosition;
                var pos = new Vector3(Random.Range(leftPos.x, rightPos.x), y, 0);

                // clamp x to X-axis cam view 
                pos.x = Mathf.Clamp(pos.x, leftPos.x + _spriteWidth, rightPos.x - _spriteWidth);
                // clamp y to 25% below and 25% above the top edge of the camera
                pos.y = Mathf.Clamp(pos.y, y - _screenBounds.y / 2, y + _screenBounds.y / 2);


                platform.transform.position = pos;
            }
        }
    }
}