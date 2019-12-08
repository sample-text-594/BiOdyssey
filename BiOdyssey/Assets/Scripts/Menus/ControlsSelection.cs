using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsSelection : MonoBehaviour
{
    public void PC() {
        SceneManager.LoadScene(10);
    }

    public void Mobile() {
        Settings.onMobile = true;
        SceneManager.LoadScene(10);
    }
}
