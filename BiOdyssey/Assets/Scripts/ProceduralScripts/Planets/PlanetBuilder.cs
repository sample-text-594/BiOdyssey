using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBuilder : MonoBehaviour {
    void Start() {
        Planet p = gameObject.AddComponent<Planet>();

        p.shapeSettings = Settings.planetSettings.shapeSettings;
        p.colourSettings = Settings.planetSettings.colourSettings;
        p.floraSettings = Settings.planetSettings.floraSettings;

        p.resolution = 120;
        p.shapeSettings.planetRadius = 50;
        p.floraSettings.generateFlora = true;

        p.GeneratePlanet();
    }
}