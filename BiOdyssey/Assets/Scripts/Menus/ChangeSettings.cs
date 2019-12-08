using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Clase que controla los cambios de ajustes del usuario en la pantalla de ajustes.
public class ChangeSettings : MonoBehaviour {
    public Slider volumeSlider;
    public Slider qualitySlider;

    private void Start() {
        volumeSlider.value = Settings.user.volume;
        qualitySlider.value = Settings.user.quality;
    }

    //Idiomas
    public void OnEnglishPressed() {
        Settings.user.spanish = false;
    }

    public void OnSpanishPressed() {
        Settings.user.spanish = true;
    }

    //Volumen
    public void OnVolumeChanged(float value) {
        Settings.user.volume = (int) value;
        AudioSource musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        musicManager.volume = value / 10f;
    }

    //Calidad de los planetas
    public void OnQualityChanged(float value) {
        Settings.user.quality = (int) value;
    }

    //Botón de volver al menu
    public void Return(int mainMenuIndex) {
        DatabaseHandler.PostUser(Settings.user, () => {
            SceneManager.LoadScene(mainMenuIndex);
        });
    }
}
