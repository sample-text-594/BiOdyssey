using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Clase que controla el registro de usuario.
public class Register : MonoBehaviour {
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField repeatPasswordInput;

    //botón de registro
    public void RegisterButton(int mainMenuIndex) {
        if (!usernameInput.text.Equals("") && !passwordInput.text.Equals("") && !repeatPasswordInput.text.Equals("") && passwordInput.text.Equals(repeatPasswordInput.text)) {
            DatabaseHandler.GetUser(usernameInput.text, user => {
                //Username already exists
            }, () => {
                //Username free
                DatabaseHandler.PostUser(Settings.user, () => {
                    Settings.user.username = usernameInput.text;
                    Settings.user.password = passwordInput.text;
                    SceneManager.LoadScene(mainMenuIndex);
                });
            });
        }
    }
}
