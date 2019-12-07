using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSettings : MonoBehaviour {
    public void OnEnglishPressed() {
        Settings.user.spanish = false;
    }

    public void OnSpanishPressed() {
        Settings.user.spanish = true;
    }

    public void OnVolumeChanged(float value) {
        Settings.user.volume = (int) value;
    }

    public void OnQualityChanged(float value) {
        Settings.user.quality = (int) value;
    }

    public void Return(int mainMenuIndex) {
        DatabaseHandler.PostUser(Settings.user, () => {
            SceneManager.LoadScene(mainMenuIndex);
        });
    }
}
