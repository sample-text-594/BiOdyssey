using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clase para tener un input de texto en móvil en el menú.
public class OSKController : MonoBehaviour {
    public GameObject osk;

    public void OnSelected() {
        if (Settings.onMobile) {
            osk.GetComponent<KeyboardScript>().TextField = GetComponent<TMP_InputField>();
            osk.SetActive(true);
        }
    }
}
