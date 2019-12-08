using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftArrowController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData) {
        playerController.OnLeftArrowDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
        playerController.OnLeftArrowUp();
    }
}
