using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.InGameMenu {
    public class DinoHp : MonoBehaviour {
        private HpManager _dinoHpScript;
        private Image _img;
        private TextMeshProUGUI _hpVal;

        private void Awake() {
            _img = GetComponent<Image>();
        }

        private void Start() {
            _dinoHpScript = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpManager>();
            _hpVal = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            FillHpBar();
        }

        private void FillHpBar() {
            _img.fillAmount = _dinoHpScript.CurrentHp / (float)HpManager.MaxHp;
            _hpVal.text = $"{_dinoHpScript.CurrentHp} / {(float)HpManager.MaxHp}";
        }
    }
}