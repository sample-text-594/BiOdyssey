using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlanet : MonoBehaviour {
    public Star starSystem;
    public Transform originalTransform;
    public Transform planetViewTransform;
    public float animationDuration = 2f;
    public Canvas ui;

    public TextMeshProUGUI planetText;

    Vector3 initAnimPos;
    Vector3 initAnimRot;
    Transform endAnim;

    bool animate;
    bool uiEnabled;
    float startTime;

    void Start() {
        animate = false;
        uiEnabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && !uiEnabled) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                transform.SetParent(hit.collider.transform);
                uiEnabled = true;
                StartAnimation(transform, planetViewTransform);
            }
        }

        if (animate) {
            Animate();
        }
    }

    private void StartAnimation(Transform start, Transform end) {
        initAnimPos = start.localPosition;
        initAnimRot = start.localEulerAngles;
        endAnim = end;
        startTime = Time.time;
        animate = true;
    }

    private void Animate() {
        if ((Time.time - startTime) >= animationDuration) {
            transform.localPosition = endAnim.localPosition;
            transform.localEulerAngles = endAnim.localEulerAngles;
            animate = false;

            if (uiEnabled != ui.gameObject.activeSelf) {
                UpdatePlanetInfo();
                ui.gameObject.SetActive(uiEnabled);
            }
        } else {
            transform.localPosition = Vector3.Lerp(initAnimPos, endAnim.localPosition, (Time.time - startTime) / animationDuration);
            transform.localEulerAngles = Vector3.Lerp(initAnimRot, endAnim.localEulerAngles, (Time.time - startTime) / animationDuration);
        }
    }

    private void UpdatePlanetInfo() {
        planetText.SetText(transform.parent.name);
    }

    //Button functions
    public void Return() {
        transform.SetParent(null);
        ui.gameObject.SetActive(false);
        uiEnabled = false;

        StartAnimation(transform, originalTransform);
    }

    public void Prev() {
        if (!transform.parent.name.Equals(starSystem.GetFirstPlanetName())) {
            Transform prevPlanet = starSystem.GetPrevPlanet(transform.parent);

            transform.SetParent(prevPlanet);

            ui.gameObject.SetActive(false);
            StartAnimation(transform, planetViewTransform);
        }
    }

    public void Next() {
        if (!transform.parent.name.Equals(starSystem.GetLastPlanetName())) {
            Transform nextPlanet = starSystem.GetNextPlanet(transform.parent);

            transform.SetParent(nextPlanet);

            ui.gameObject.SetActive(false);
            StartAnimation(transform, planetViewTransform);
        }
    }

    public void Fly(int sceneId) {
        SceneManager.LoadScene(sceneId);
    }
}
