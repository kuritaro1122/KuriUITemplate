using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuriTaro.UI {
    public class BlinkManager : BaseBlinkCon {
        [SerializeField] List<BaseBlinkCon> blinkList = new List<BaseBlinkCon>();
        private Color tempColor = new Color();

        public override Color GetColor() {
            return this.tempColor;
        }
        public override void SetColor(Color color) {
            foreach (var b in this.blinkList) {
                b.SetBlinking(blinking:false);
                Color _color = b.GetColor();
                _color.a = color.a;
                b.SetColor(_color);
            }
        }
    }
}
