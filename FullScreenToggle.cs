using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class FullScreenToggle : MonoBehaviour {
    [SerializeField] Toggle toggle;

    void Start() {
        this.toggle.isOn = Screen.fullScreen;
        this.toggle.onValueChanged.AddListener(ChangeFullScreen);
    }
    void OnValidate() {
        if (this.toggle == null) this.toggle = GetComponent<Toggle>();
    }
    private void ChangeFullScreen(bool fullScreen) {
        Screen.fullScreen = fullScreen;
    }
}
