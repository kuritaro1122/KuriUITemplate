using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HyperNova;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace EventSystemExpansion {
    //[AddComponentMenu("EventSystemExpansion/EventSystemCheckker")]
    public class EventSystemCheckker : MonoBehaviour {
        [SerializeField] EventSystem eventSystem;
        [SerializeField] bool ForceSelect = true;
        [SerializeField, Disable] GameObject selectCurrent = null;
        private GameObject preSelectGameObject = null;
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

            if (!DefaultAcceptButton() && HyperNova.InputControl.AcceptButton) {
                if (selectCurrent != null) {
                    if (this.selectCurrent.GetComponent<IPointerClickHandler>() == null) return;
                    var eventData = new PointerEventData(eventSystem);
                    eventData.position = this.selectCurrent.transform.position;
                    eventData.pressPosition = this.selectCurrent.transform.position;
                    eventData.button = PointerEventData.InputButton.Left;
                    ExecuteEvents.Execute<IPointerClickHandler>(this.selectCurrent, eventData, (handler, ev) => handler.OnPointerClick((PointerEventData)ev));
                 }
            }
            bool DefaultAcceptButton() {
                if (Gamepad.current == null) {
                    return Keyboard.current.enterKey.wasPressedThisFrame;
                } else {
                    return Keyboard.current.enterKey.wasPressedThisFrame || Gamepad.current.aButton.wasPressedThisFrame || Gamepad.current.crossButton.wasPressedThisFrame;
                }
            }
/*#if UNITY_EDITOR
            Cursor.visible = this.selectCurrent != null && this.selectCurrent.activeInHierarchy;
#else
            Cursor.visible = false;
#endif*/
        }
    }
}