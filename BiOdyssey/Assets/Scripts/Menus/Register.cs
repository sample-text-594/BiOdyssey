using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Register : MonoBehaviour {
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField repeatPasswordInput;

    public void RegisterButton(int mainMenuIndex) {
        if (!usernameInput.text.Equals("") && !passwordInput.text.Equals("") && !repeatPasswordInput.text.Equals("") && passwordInput.text.Equals(repeatPasswordInput.text)) {
            Settings.user.username = usernameInput.text;
            Settings.user.password = passwordInput.text;

            DatabaseHandler.PostUser(Settings.user, () => {
                SceneManager.LoadScene(mainMenuIndex);
            });
        }
    }
}
