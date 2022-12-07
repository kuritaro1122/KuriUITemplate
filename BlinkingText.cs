using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {
    [SerializeField] Text text;
    [SerializeField] bool auto;
    public Text GetText() => this.text;
    private float time = 0f;

    // Update is called once per frame
    void Update() {
        if (this.auto) Blinking();
    }

    public void Blinking() {
        //text.gameObject.SetActive(true);
        this.time += 1f * Time.unscaledDeltaTime;
        this.time %= 2f;
        UpdateColor();
    }
    public void NoBlinking() {
        //this.text.gameObject.SetActive(false);
        this.time = 0f;
        UpdateColor();
    }
    private void UpdateColor() {
        Color color = this.text.color;
        this.time %= 2f;
        if (this.time < 1f) {
            color.a = Mathf.Lerp(0, 1, this.time);
        } else {
            color.a = Mathf.Lerp(1, 0, this.time - 1f);
        }
        this.text.color = color;
    }
}
