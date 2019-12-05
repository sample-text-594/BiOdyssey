using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToPlanet : MonoBehaviour {
    public Star starSystem;
    public Transform originalTransform;
    public Transform planetViewTransform;
    public float animationDuration = 2f;

    public GameObject uiSystem;
    public GameObject uiPlanet;

    public TextMeshProUGUI planetText;
    public Slider fuel;

    public float fuelPerJump = 0.2f;

    public SceneLoader sl;

    Vector3 initAnimPos;
    Quaternion initAnimRot;
    Transform endAnim;

    bool animate;
    bool uiPlanetEnabled;
    [HideInInspector]
    public bool uiSystemEnabled;
    float startTime;

    public void GtpStart() {
        animate = false;
        uiPlanetEnabled = false;
        uiSystemEnabled = false;

        fuel.value = Settings.fuel;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && uiSystemEnabled) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                uiSystem.SetActive(false);
                uiSystemEnabled = false;

                transform.SetParent(hit.collider.transform);
                uiPlanetEnabled = true;
                StartAnimation(transform, planetViewTransform);
            }
        }

        if (animate) {
            Animate();
        }
    }

    private void StartAnimation(Transform start, Transform end) {
        initAnimPos = start.localPosition;
        initAnimRot = start.localRotation;
        endAnim = end;
        startTime = Time.time;
        animate = true;
    }

    private void Animate() {
        if ((Time.time - startTime) >= animationDuration) {
            transform.localPosition = endAnim.localPosition;
            transform.localEulerAngles = endAnim.localEulerAngles;
            animate = false;

            if (uiPlanetEnabled != uiPlanet.activeSelf) {
                UpdatePlanetInfo();
                uiPlanet.SetActive(uiPlanetEnabled);
            }

            if (uiSystemEnabled != uiSystem.activeSelf) {
                uiSystem.SetActive(uiSystemEnabled);
            }
        } else {
            transform.localPosition = Vector3.Lerp(initAnimPos, endAnim.localPosition, (Time.time - startTime) / animationDuration);
            transform.localRotation = Quaternion.Lerp(initAnimRot, endAnim.localRotation, (Time.time - startTime) / animationDuration);
        }
    }

    private void UpdatePlanetInfo() {
        planetText.SetText(transform.parent.name);
    }

    //Button functions
    public void Return() {
        transform.SetParent(null);
        uiPlanet.gameObject.SetActive(false);
        uiPlanetEnabled = false;
        uiSystemEnabled = true;

        StartAnimation(transform, originalTransform);
    }

    public void Prev() {
        if (!transform.parent.name.Equals(starSystem.GetFirstPlanetName())) {
            Transform prevPlanet = starSystem.GetPrevPlanet(transform.parent);

            transform.SetParent(prevPlanet);

            uiPlanet.gameObject.SetActive(false);
            StartAnimation(transform, planetViewTransform);
        }
    }

    public void Next() {
        if (!transform.parent.name.Equals(starSystem.GetLastPlanetName())) {
            Transform nextPlanet = starSystem.GetNextPlanet(transform.parent);

            transform.SetParent(nextPlanet);

            uiPlanet.gameObject.SetActive(false);
            StartAnimation(transform, planetViewTransform);
        }
    }

    public void Fly() {
        Planet p = gameObject.GetComponentInParent<Planet>();

        Settings.planetSettings.shapeSettings = p.shapeSettings;
        Settings.planetSettings.colourSettings = p.colourSettings;
        Settings.planetSettings.floraSettings = p.floraSettings;

        Settings.actualPlanet = ((int)p.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre.x) % 10;

        Settings.returningFromPlanet = true;

        sl.LoadScene();
    }

    public void ReturnHome(int sceneId) {
        SceneManager.LoadScene(sceneId);
    }

    public void NextSystem() {
        if (Settings.fuel > fuelPerJump) {
            Settings.fuel -= fuelPerJump;
            Settings.returningFromPlanet = false;

            //Subimos el sistema con los cambios realizados
            DatabaseHandler.PostSystem(Settings.system, () => {
                //Obtenemos el siguiente sistema
                Settings.system.seed++;

                //Comprobar si el sistema existe en la base de datos
                DatabaseHandler.GetSystem(Settings.system.seed.ToString(), system => {
                    //Si existe lo recreamos
                    Settings.system = system;

                    //Cargamos el sistema
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                });
            });
        }
    }
}
