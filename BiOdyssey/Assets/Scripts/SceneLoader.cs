using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour {
    public int sceneId;
    public GameObject loadingUI;
    public TextMeshProUGUI loadingText;

    bool loadScene = false;

    void Update() {
        if (loadScene) {
            loadingText.alpha = Mathf.PingPong(Time.time, 1);
        }
    }

    public void LoadScene() {
        loadScene = true;
        loadingUI.SetActive(true);
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene() {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

        while (!async.isDone) {
            yield return null;
        }
    }
}
