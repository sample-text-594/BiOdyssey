using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase que simplemente elige el tutorial a mostrar en función del idioma escogido.
public class StartTutorial : MonoBehaviour {
    public void EnterTutorial() {
        if (Settings.user.spanish) {
            SceneManager.LoadScene(9);
        } else {
            SceneManager.LoadScene(8);
        }
    }
}
