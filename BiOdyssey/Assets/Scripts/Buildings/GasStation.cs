using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GasStation : MonoBehaviour {
    public TextMeshProUGUI timeText;
    public GameObject reduceTimeButton;
    public GameObject flyButton;
    public SceneLoader sl;

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
        //Settings.timeLeftFill = tiempoRestante
        Settings.timeLeftFill = 1;

        hours = Settings.timeLeftFill / 3600;
        minutes = (Settings.timeLeftFill % 3600) / 60;
        seconds = (Settings.timeLeftFill % 3600) % 60;

        SetText();
    }

    void Update() {
        if (Settings.timeLeftFill > 0) {
            if (accumulatedTime == -1f) {
                accumulatedTime = 0f;
            } else {
                accumulatedTime += Time.deltaTime;
            }

            if (accumulatedTime > 1f) {
                accumulatedTime -= 1f;
                Settings.timeLeftFill--;

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

                reduceTimeButton.SetActive(false);
                flyButton.SetActive(true);
            }
        }
    }

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

    public void Fly() {
        //Comprobar si el sistema existe en la base de datos
        DatabaseHandler.GetSystem(Settings.system.seed.ToString(), system => {
            //Si existe lo recreamos
            Settings.system = system;

            //Cargamos el sistema
            sl.LoadScene();
        }, () => {
            //Si no existe inicializamos los campos por defecto
            Settings.system.name = "";
            Settings.system.userName = "";

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 3; j++) {
                    Settings.system.planets[i].creatures[j] = "";
                    Settings.system.planets[i].creatureNames[j] = "";
                    Settings.system.planets[i].userNames[j] = "";
                }
            }

            //Cargamos el sistema
            sl.LoadScene();
        });
    }
}
