using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clase que maneja la interacción del escáner con una criatura
public class DiscoverCreature : MonoBehaviour {
    public GameObject uiNewCreature;
    public TextMeshProUGUI creatureName;
    public TextMeshProUGUI creatureUserName;
    public GameObject renameButton;
    public GameObject skipButton;
    public GameObject okButton;
    public GameObject renameText;

    public GameObject uiRenameCreature;
    public TMP_InputField creatureNameInput;

    bool isDiscovered;
    int creatureIndex;

    public void Discover(int index, PlayerController pc) {
        creatureIndex = index;

        //Comprobar si la criatura ya esta descubierta
        isDiscovered = !Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex].Equals("");

        //Si ya lo está te dice su nombre y no deja renombrarla
        if (isDiscovered) {
            renameButton.SetActive(false);
            skipButton.SetActive(false);
            renameText.SetActive(false);

        //Si no, puedes bautizarla
        } else {
            pc.RechargeEnergy();
            okButton.SetActive(false);

            Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex] = "Creature " + Settings.system.planets[Settings.actualPlanet].creatures[creatureIndex];
            Settings.system.planets[Settings.actualPlanet].userNames[creatureIndex] = Settings.user.username;
        }

        creatureName.SetText(Settings.system.planets[Settings.actualPlanet].creatureNames[creatureIndex]);
        creatureUserName.SetText(Settings.system.planets[Settings.actualPlanet].userNames[creatureIndex]);

        gameObject.SetActive(true);
    }

    //Método para generar el diálogo de bautizo
    public void Rename() {
        uiNewCreature.SetActive(false);
        uiRenameCreature.SetActive(true);
    }

    //Saltar nombrar criatura
    public void Skip() {
        gameObject.SetActive(false);

        renameButton.SetActive(true);
        skipButton.SetActive(true);
        renameText.SetActive(true);
        okButton.SetActive(true);
    }

    //Botón de confirmar y guardado del nombre
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
