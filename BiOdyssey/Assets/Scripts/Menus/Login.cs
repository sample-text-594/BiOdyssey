using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour {
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    public void LoginButton(int mainMenuIndex) {
        if (!usernameInput.text.Equals("") && !passwordInput.text.Equals("")) {
            DatabaseHandler.GetUser(usernameInput.text, user => {
                if (user.password.Equals(passwordInput.text)) {
                    Settings.user = user;
                    SceneManager.LoadScene(mainMenuIndex);
                } else {
                    //Password mismatched
                }
            }, () => { 
                //User not found
            });
        }
    }
}
