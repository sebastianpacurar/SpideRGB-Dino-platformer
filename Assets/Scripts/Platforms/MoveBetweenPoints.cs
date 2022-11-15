using UnityEngine;

namespace Platforms {
    public class MoveBetweenPoints : MonoBehaviour {
        [SerializeField] private GameObject[] locations;
        private int _index;

        [SerializeField] private float speed = 2f;
        private Animator _animator;
        private bool _isStatic;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            _isStatic = locations[0].transform.position == locations[1].transform.position;
            _animator.SetBool("active", !_isStatic);
        }

        private void Update() {
            if (_isStatic) return;
            if (Vector2.Distance(locations[_index].transform.position, gameObject.transform.position) < 0.1f) {
                _index++;
                if (_index >= locations.Length) {
                    _index = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, locations[_index].transform.position, speed * Time.deltaTime);
        }
    }
}