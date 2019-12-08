using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OSKController : MonoBehaviour {
    public GameObject osk;

    public void OnSelected() {
        if (Settings.onMobile) {
            osk.GetComponent<KeyboardScript>().TextField = GetComponent<TMP_InputField>();
            osk.SetActive(true);
        }
    }
}
