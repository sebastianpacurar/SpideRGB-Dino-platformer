using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class SwitchPanel : MonoBehaviour {
        [SerializeField] private GameObject[] dinoContainers;
        private string _currColor = Rgb.Green.ToString();
        private GameObject _dino;

        private void Start() {
            _dino = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update() {
            HandleDinoSelection();
        }

        //TODO: find a better way to handle this
        private void HandleDinoSelection() {
            if (!_currColor.Equals(_dino.name.Split(" ")[0])) {
                var dinoColor = _dino.name.Split(" ")[0];

                foreach (var obj in dinoContainers) {
                    var outlayerImage = obj.transform.GetChild(0).GetComponent<Image>();
                    outlayerImage.color = obj.CompareTag(dinoColor) ? outlayerImage.color.WithAlpha(255) : outlayerImage.color.WithAlpha(0);

                    var animator = obj.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
                    animator.SetBool("selected", obj.CompareTag(dinoColor));

                    _currColor = dinoColor;
                }
            }
        }
    }
}