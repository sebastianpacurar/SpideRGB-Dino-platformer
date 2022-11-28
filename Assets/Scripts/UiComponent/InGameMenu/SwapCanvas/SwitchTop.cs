using UnityEngine;

namespace UiComponent.InGameMenu.SwapCanvas {
    public class SwitchTop : MonoBehaviour {
        [SerializeField] private GameObject[] leftDino, selectedDino, rightDino;

        public void Swap(string oldColor, string newColor, string direction) {
            var switchWith = direction.Equals("left") ? leftDino : rightDino;

            // set the active dino as selected, and start running animation
            foreach (var obj in selectedDino) {
                obj.SetActive(obj.CompareTag(newColor));
                if (obj.activeSelf) {
                    obj.GetComponent<Animator>().SetBool("selected", obj.CompareTag(newColor));
                }
            }

            // set the active dino as prior selected, and start idle animation
            foreach (var obj in switchWith) {
                obj.SetActive(obj.CompareTag(oldColor));
                if (obj.activeSelf) {
                    obj.GetComponent<Animator>().SetBool("selected", false);
                }
            }
        }

        // get the tag of the left dino
        public string GetLeftActiveColor() {
            var color = "";
            foreach (var obj in leftDino) {
                if (!obj.activeSelf) continue;
                color = obj.tag;
                break;
            }

            return color;
        }

        // get the tag of the right dino
        public string GetRightActiveColor() {
            var color = "";
            foreach (var obj in rightDino) {
                if (!obj.activeSelf) continue;
                color = obj.tag;
                break;
            }

            return color;
        }
    }
}