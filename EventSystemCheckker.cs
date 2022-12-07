using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace KuriTaro.EventSystemExpansion {
    public class EventSystemCheckker : MonoBehaviour {
        [SerializeField] EventSystem eventSystem;
        [SerializeField] bool ForceSelect = true;
        private GameObject selectCurrent = null;
        private GameObject preSelectGameObject = null;
        private static bool buttonDown = false;
        void Start() {
            if (this.eventSystem == null) this.eventSystem = EventSystem.current;
        }
        void Update() {
            if (this.eventSystem != null) this.eventSystem = EventSystem.current;
            GameObject current = this.eventSystem.currentSelectedGameObject;
            this.selectCurrent = current;
            if (this.ForceSelect) {
                if (current == null) {
                    if (this.preSelectGameObject != null) this.eventSystem.SetSelectedGameObject(preSelectGameObject);
                    else this.eventSystem.SetSelectedGameObject(this.eventSystem.firstSelectedGameObject);
                }
            }
            if (current != null) this.preSelectGameObject = current;

            if (DefaultAcceptButton()) {
                if (selectCurrent != null && !buttonDown) {
                    buttonDown = true;
                    if (this.selectCurrent.GetComponent<IPointerClickHandler>() == null) return;
                    var eventData = new PointerEventData(eventSystem);
                    eventData.position = this.selectCurrent.transform.position;
                    eventData.pressPosition = this.selectCurrent.transform.position;
                    eventData.button = PointerEventData.InputButton.Left;
                    ExecuteEvents.Execute<IPointerClickHandler>(this.selectCurrent, eventData, (handler, ev) => handler.OnPointerClick((PointerEventData)ev));
                } 
            } else buttonDown = false;
        }
        protected virtual bool DefaultAcceptButton() {
            return false;
        }
    }
}