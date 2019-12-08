using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {
    public GameObject[] tutorialSlides;
    int index;

    private void Start() {
        index = 0;
    }

    public void Previous() {
        if (index > 0) {
            tutorialSlides[index].SetActive(false);
            index--;
            tutorialSlides[index].SetActive(true);
        } else {
            SceneManager.LoadScene(2);
        }
    }

    public void Next() {
        if (index < tutorialSlides.Length - 1) {
            tutorialSlides[index].SetActive(false);
            index++;
            tutorialSlides[index].SetActive(true);
        } else {
            SceneManager.LoadScene(2);
        }
    }
}
