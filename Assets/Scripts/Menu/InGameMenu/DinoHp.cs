using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.InGameMenu {
    public class DinoHp : MonoBehaviour {
        private HpManager _dinoHpScript;
        private Image _img;
        [SerializeField] private TextMeshProUGUI hpVal;

        private void Awake() {
            _img = GetComponent<Image>();
        }

        private void Start() {
            _dinoHpScript = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpManager>();
            hpVal = transform.Find("ValueTxt").GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            FillHpBar();
        }

        private void FillHpBar() {
            _img.fillAmount = _dinoHpScript.CurrentHp / (float)HpManager.MaxHp;
            hpVal.text = $"{_dinoHpScript.CurrentHp} / {(float)HpManager.MaxHp}";
        }
    }
}