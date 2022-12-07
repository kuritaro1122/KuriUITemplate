using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextInteractableColor : MonoBehaviour {
    private Component selfUI = null;
    private List<Component> maskableGraphic = new List<Component>();
    [SerializeField] Color interactableColor = Color.white;
    [SerializeField] Color nonInteractableColor = Color.black;
    private bool interactable = true;

    // Start is called before the first frame update
    void Start() {
        //if (this.selfButton == null) this.selfButton.GetComponent<Button>();
        //if (this.maskableGraphic == null) this.selfButton.
        Init();
    }

    // Update is called once per frame
    void Update() {
        Selectable selectable = selfUI as Selectable;
        if (this.interactable != selectable.interactable) {
            this.interactable = selectable.interactable;
            foreach (Component g in this.maskableGraphic) {
                MaskableGraphic _g = g as MaskableGraphic;
                _g.color = this.interactable ? this.interactableColor : this.nonInteractableColor;
            }
        }
    }

    private void Init() {
        this.selfUI = this.GetComponent<Selectable>();
        this.maskableGraphic = new List<Component>();
        foreach (var g in this.GetComponentsInChildren<MaskableGraphic>()) {
            if (!g.gameObject.Equals(this.gameObject)) {
                this.maskableGraphic.Add(g as Component);
            }
        }
    }
}
