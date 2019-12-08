using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownArrowController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData) {
        playerController.OnDownArrowDown();
    }

    public void OnPointerUp(PointerEventData eventData) {
        playerController.OnDownArrowUp();
    }
}
