using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KuriTaro.UI {
    public class BlinkImageCon : BaseBlinkCon {
        [SerializeField] Image image;
        public override Color GetColor() {
            return this.image.color;
        }
        public override void SetColor(Color color) {
            this.image.color = color;
        }
    }
}