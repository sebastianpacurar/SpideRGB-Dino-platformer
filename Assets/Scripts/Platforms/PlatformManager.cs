using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Platforms {
    public class PlatformManager : MonoBehaviour {
        [SerializeField] private GameObject[] platforms;

        // [SerializeField] private TextMeshProUGUI scoreText;
        [HideInInspector] public int score = 0;
        // private int _displayedScore = 0;

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

        IEnumerator SpawnPlatforms() {
            while (true) {
                yield return new WaitForSeconds(1f);

                var platform = Instantiate(platforms[Random.Range(0, platforms.Length)], transform);
                platform.name = $"{name} - {System.Guid.NewGuid().ToString()}";

                var cmTransform = _cm.transform.position;
                var x = _screenBounds.x + cmTransform.x;
                var y = _screenBounds.y + cmTransform.y;

                var pos = new Vector3(Random.Range(-x, x), y, 0);
                pos.x = Mathf.Clamp(pos.x, -x + _spriteWidth, x - _spriteWidth);

                platform.transform.position = pos;
            }
        }
    }
}