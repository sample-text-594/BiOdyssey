using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpArrowController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData) {
        playerController.OnUpArrowDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
        playerController.OnUpArrowUp();
    }
}
