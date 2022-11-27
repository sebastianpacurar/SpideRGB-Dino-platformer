using UnityEngine;
using Random = UnityEngine.Random;

namespace Platforms {
    public class MoveBetweenPoints : MonoBehaviour {
        [SerializeField] private GameObject[] locations;
        private int _index;

        private float _speed;
        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
            _speed = GameManager.Instance.GameDifficulty switch {
                (int)Difficulty.Hero => Random.Range(2, 3),
                (int)Difficulty.Superhero => Random.Range(4, 5),
                _ => 0f,
            };
        }

        private void Start() {
            _animator.SetBool("active", _speed > 0f);
        }

        private void Update() {
            if (_speed == 0f) return;
            if (Vector2.Distance(locations[_index].transform.position, gameObject.transform.position) < 0.1f) {
                _index++;
                if (_index >= locations.Length) {
                    _index = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, locations[_index].transform.position, _speed * Time.deltaTime);
        }
    }
}