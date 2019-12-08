using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightArrowController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData) {
        playerController.OnRightArrowDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
        playerController.OnRightArrowUp();
    }
}
