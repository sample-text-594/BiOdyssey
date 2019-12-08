using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Clase usada para manejar los cambios entre escenas
public class SceneLoader : MonoBehaviour {
    public int sceneId;
    public GameObject loadingUI;
    public GameObject loadingGizmo;

    bool loadScene = false;

    void Update() {
        if (loadScene) {
            loadingGizmo.transform.localEulerAngles = new Vector3(loadingGizmo.transform.localEulerAngles.x, loadingGizmo.transform.localEulerAngles.y, loadingGizmo.transform.localEulerAngles.z - 200 * Time.deltaTime);
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
