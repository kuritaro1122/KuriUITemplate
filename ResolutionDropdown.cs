using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ResolutionDropdown : MonoBehaviour {
    [SerializeField] Dropdown dropdown;
    private List<Resolution> resolutions = new();

    void Start() {
        SetDropdown();
    }
    void OnValidate() {
        if (this.dropdown == null) this.dropdown = GetComponent<Dropdown>();
    }

    private void SetDropdown() {
        this.dropdown.ClearOptions();
        int currentIndex = 0;
        List<string> options = new();
        int step = Screen.currentResolution.width / (640);
        int k = 0;
        for (int i = 0; i <= step; i++) {
            if (640 * i < 640) continue;
            Resolution resolution;
            resolution = new();
            resolution.width = 640 * i;
            resolution.height = 360 * i;
            this.resolutions.Add(resolution);
            options.Add(resolution.width.ToString() + "x" + resolution.height.ToString());
            if (Screen.width == resolution.width && Screen.height == resolution.height) {
                currentIndex = k;
            }
            k++;
        }
        this.dropdown.AddOptions(options);
        this.dropdown.onValueChanged.AddListener(SetResolution);
        this.dropdown.value = currentIndex;
    }
    private void SetResolution(int index) {
        Resolution resolution = this.resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    [System.Serializable]
    struct Resolution {
        public int width;
        public int height;
    }
}
