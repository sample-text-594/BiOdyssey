using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase que controla los cambios de ajustes del usuario en la pantalla de ajustes.
public class ChangeSettings : MonoBehaviour {

    //Idiomas
    public void OnEnglishPressed() {
        Settings.user.spanish = false;
    }

    public void OnSpanishPressed() {
        Settings.user.spanish = true;
    }

    //Volúmenes
    public void OnVolumeChanged(float value) {
        Settings.user.volume = (int) value;
    }

    public void OnQualityChanged(float value) {
        Settings.user.quality = (int) value;
    }

    //Botón de volver al menú
    public void Return(int mainMenuIndex) {
        DatabaseHandler.PostUser(Settings.user, () => {
            SceneManager.LoadScene(mainMenuIndex);
        });
    }
}
