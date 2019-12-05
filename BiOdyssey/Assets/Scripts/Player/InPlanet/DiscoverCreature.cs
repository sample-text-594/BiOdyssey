using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscoverCreature : MonoBehaviour {
    public GameObject uiNewCreature;
    public TextMeshProUGUI creatureName;
    public GameObject renameButton;
    public GameObject skipButton;
    public GameObject okButton;
    public GameObject renameText;

    public GameObject uiRenameCreature;
    public TMP_InputField creatureNameInput;

    bool isDiscovered;

    public void Discover(string sn) {
        //Comprobar en la base de datos si el sistema ya esta descubierto
        isDiscovered = false;

        if (isDiscovered) {
            renameButton.SetActive(false);
            skipButton.SetActive(false);
            renameText.SetActive(false);
        } else {
            okButton.SetActive(false);
        }

        creatureName.SetText(sn);
    }

    public void Rename() {
        uiNewCreature.SetActive(false);
        uiRenameCreature.SetActive(true);
    }

    public void Skip() {
        gameObject.SetActive(false);
    }

    public void Confirm() {
        string newName = creatureNameInput.text;

        if (!newName.Equals("")) {
            //star.RenameStar(newName);
            creatureName.SetText(newName);
        }

        uiRenameCreature.SetActive(false);
        uiNewCreature.SetActive(true);

        renameButton.SetActive(false);
        skipButton.SetActive(false);
        renameText.SetActive(false);
        okButton.SetActive(true);
    }
}
