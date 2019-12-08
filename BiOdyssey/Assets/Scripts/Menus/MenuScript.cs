using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase que controla los cambios de escena desde el menú.
public class MenuScript : MonoBehaviour {
    public void LoadScene(int index) {
        SceneManager.LoadScene(index);
    }
}
