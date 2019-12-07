using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscoverSystem : MonoBehaviour {
    public Star star;
    public GameObject uiSystem;
    public GoToPlanet gtp;

    public GameObject uiNewSystem;
    public TextMeshProUGUI systemName;
    public TextMeshProUGUI systemUserName;
    public GameObject renameButton;
    public GameObject skipButton;
    public GameObject okButton;
    public GameObject renameText;

    public GameObject uiRenameSystem;
    public TMP_InputField starNameInput;

    bool isDiscovered;

    public void DiscoverStar() {
        //Comprobar en la base de datos si el sistema ya esta descubierto
        isDiscovered = !Settings.system.name.Equals("");

        if (isDiscovered) {
            renameButton.SetActive(false);
            skipButton.SetActive(false);
            renameText.SetActive(false);
        } else {
            okButton.SetActive(false);
            Settings.system.name = star.gameObject.name;
            Settings.system.userName = Settings.user.username;
        }

        systemName.SetText(star.gameObject.name);
        systemUserName.SetText(Settings.system.userName);
    }

    public void Rename() {
        uiNewSystem.SetActive(false);
        uiRenameSystem.SetActive(true);
    }

    public void Skip() {
        gtp.uiSystemEnabled = true;

        gameObject.SetActive(false);
        uiSystem.SetActive(true);
    }

    public void Confirm() {
        string newName = starNameInput.text;

        if (!newName.Equals("")) {
            star.RenameStar(newName);
            systemName.SetText(newName);
            Settings.system.name = newName;
        }

        uiRenameSystem.SetActive(false);
        uiNewSystem.SetActive(true);

        renameButton.SetActive(false);
        skipButton.SetActive(false);
        renameText.SetActive(false);
        okButton.SetActive(true);
    }
}
