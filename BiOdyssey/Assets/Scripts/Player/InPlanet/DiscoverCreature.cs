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
    int creatureIndex;

    public void Discover(int index) {
        creatureIndex = index;

        //Comprobar si la criatura ya esta descubierta
        isDiscovered = !Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex].Equals("");

        if (isDiscovered) {
            renameButton.SetActive(false);
            skipButton.SetActive(false);
            renameText.SetActive(false);

            creatureName.SetText(Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex]);
        } else {
            okButton.SetActive(false);

            creatureName.SetText("Creature " + Settings.system.planets[Settings.actualPlanet].creatures[creatureIndex]);
        }
        gameObject.SetActive(true);
    }

    public void Rename() {
        uiNewCreature.SetActive(false);
        uiRenameCreature.SetActive(true);
    }

    public void Skip() {
        gameObject.SetActive(false);

        renameButton.SetActive(true);
        skipButton.SetActive(true);
        renameText.SetActive(true);
        okButton.SetActive(true);
    }

    public void Confirm() {
        string newName = creatureNameInput.text;

        if (!newName.Equals("")) {
            Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex] = newName;
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
