using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : MonoBehaviour {
    public void EnterTutorial() {
        if (Settings.user.spanish) {
            SceneManager.LoadScene(9);
        } else {
            SceneManager.LoadScene(8);
        }
    }
}
