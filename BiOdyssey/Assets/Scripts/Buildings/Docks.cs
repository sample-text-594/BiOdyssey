using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clase que controla el comportamiento del taller.
public class Docks : MonoBehaviour {

    //Atributos
    public TextMeshProUGUI timeText;
    public GameObject reduceTimeButton;
    public GameObject ship;

    int hours;
    int minutes;
    int seconds;

    float accumulatedTime;

    bool done;

    void Start() {
        done = false;
        accumulatedTime = -1f;
        hours = 0;
        minutes = 0;
        seconds = 0;

        //Comprobar cuanto tiempo ha pasado desde la ultima vez
        //Settings.timeLeftRepair = tiempoRestante
        Settings.timeLeftRepair = 3720;

        hours = Settings.timeLeftRepair / 3600;
        minutes = (Settings.timeLeftRepair % 3600) / 60;
        seconds = (Settings.timeLeftRepair % 3600) % 60;

        //Cambia el texto en función del tiempo restante.
        SetText();
    }

    void Update() {
        //Cada segundo que pasa cambia el texto del tiempo restante.
        if (Settings.timeLeftFill > 0) {
            if (accumulatedTime == -1f) {
                accumulatedTime = 0f;
            } else {
                accumulatedTime += Time.deltaTime;
            }

            if (accumulatedTime > 1f) {
                accumulatedTime -= 1f;
                Settings.timeLeftRepair--;

                if (seconds > 0) {
                    seconds--;
                } else {
                    if (minutes > 0) {
                        minutes--;
                        seconds = 59;
                    } else {
                        if (hours > 0) {
                            hours--;
                            minutes = 59;
                            seconds = 59;
                        }
                    }
                }

                SetText();
            }
        } else {
            if (!done) {
                done = true;
            }
        }
    }

    //Método que cambia el texto del tiempo.
    void SetText() {
        string time;
        time = "0" + hours + ":";
        time += minutes > 9
            ? minutes + ":"
            : "0" + minutes + ":";
        time += seconds > 9
            ? "" + seconds
            : "0" + seconds;

        timeText.SetText(time);
    }
}
