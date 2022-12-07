using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KuriTaro.UI {
    public class BlinkTextCon : BaseBlinkCon {
        [SerializeField] Text text;
        public override Color GetColor() {
            return this.text.color;
        }
        public override void SetColor(Color color) {
            this.text.color = color;
        }
    }
}