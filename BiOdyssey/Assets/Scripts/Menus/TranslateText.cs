using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateText : MonoBehaviour {
    public string traduccion;
    private void Start() {
        if (Settings.user.spanish) {
            GetComponent<TextMeshProUGUI>().SetText(traduccion);
        }
    }
}
