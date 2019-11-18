using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizeUI : MonoBehaviour {
    public CameraController cameraController;
    public float cameraOffset = 10f;

    public Planet planet;
    public GameObject menuButton;
    public GameObject customizeButton;
    public GameObject customizeUI;

    public ShapeSettings[] terrains;
    public ColourSettings[] colors;
    public FloraSettings[] floras;

    void Start() {
        
    }

    public void startCustomization() {
        cameraController.canInteract = false;
        cameraController.canRotate = false;

        menuButton.SetActive(false);
        customizeButton.SetActive(false);
        customizeUI.SetActive(true);

        Camera.main.transform.localPosition += Camera.main.transform.right * cameraOffset;
    }

    public void endCustomization() {
        cameraController.canInteract = true;
        cameraController.canRotate = true;

        menuButton.SetActive(true);
        customizeButton.SetActive(true);
        customizeUI.SetActive(false);

        Camera.main.transform.localPosition -= Camera.main.transform.right * cameraOffset;
    }

    public void onTerrainChange(int pos) {
        planet.shapeSettings = terrains[pos].Clone();
        planet.shapeSettings.planetRadius = 50f;
    }

    public void onColorChange(int pos) {
        planet.colourSettings = colors[pos].Clone();
    }

    public void onFloraChange(int pos) {
        planet.floraSettings = floras[pos].Clone();
        planet.floraSettings.generateFlora = true;
    }

    public void generatePlanet() {
        planet.GeneratePlanet();
    }

    public void Return(int sceneId) {
        SceneManager.LoadScene(sceneId);
    }
}
