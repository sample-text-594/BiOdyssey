using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverSystem : MonoBehaviour {
    public GameObject uiSystem;
    public GoToPlanet gtp;

    public GameObject renameButton;
    public GameObject skipButton;
    public GameObject okButton;
    public GameObject renameText;

    bool isDiscovered;

    void Start() {
        //Comprobar en la base de datos si el sistema ya esta descubierto
        isDiscovered = false;

        if (isDiscovered) {
            renameButton.SetActive(false);
            skipButton.SetActive(false);
            renameText.SetActive(false);
        } else {
            okButton.SetActive(false);
        }
    }

    public void Rename() {

    }

    public void Skip() {
        gtp.uiSystemEnabled = true;

        gameObject.SetActive(false);
        uiSystem.SetActive(true);
    }
}
