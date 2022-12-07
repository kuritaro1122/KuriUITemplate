using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuriTaro.UI {
    public abstract class BaseBlinkCon : MonoBehaviour {
        [SerializeField] AnimationCurve blinkInCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] AnimationCurve blinkOutCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField, Range(0f, 1f)] float min = 0f;
        [SerializeField, Range(0f, 1f)] float max = 1f;
        [SerializeField] bool blinking = true;
        [SerializeField] float blinkTime = 2f;
        private float time = 0f;

        protected virtual void Update() {
            if (this.blinking) UpdateBlink();
        }

        public void SetBlinking(bool blinking) {
            this.blinking = blinking;
        }
        public void UpdateBlink() {
            this.time += 1f * Time.unscaledDeltaTime;
            this.time %= 2f;
            UpdateColor();
        }
        public void InitBlinking() {
            this.time = 0f;
            UpdateColor();
        }

        public abstract Color GetColor();
        public abstract void SetColor(Color color);

        private void UpdateColor() {
            Color color = GetColor();
            this.time %= blinkTime;
            float alfa;
            if (this.time < this.blinkTime / 2f) {
                float t = Mathf.Lerp(min, max, this.time);
                alfa = this.blinkInCurve.Evaluate(t);
            } else {
                float t = Mathf.Lerp(max, min, this.time - this.blinkTime / 2f);
                alfa = this.blinkOutCurve.Evaluate(t);
            }
            color.a = alfa;
            SetColor(color);
        }
    }
}