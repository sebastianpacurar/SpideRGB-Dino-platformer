using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGameMenu {
    public class DinoHp : MonoBehaviour {
        private LifeManager _lifeManager;
        private Image _img;
        [SerializeField] private TextMeshProUGUI hpVal;

        private void Awake() {
            _img = GetComponent<Image>();
        }

        private void Start() {
            _lifeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeManager>();
            hpVal = transform.Find("ValueTxt").GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            FillHpBar();
        }

        private void FillHpBar() {
            _img.fillAmount = _lifeManager.CurrentHp / (float)LifeManager.MaxHp;
            hpVal.text = $"{_lifeManager.CurrentHp} / {(float)LifeManager.MaxHp}";
        }
    }
}