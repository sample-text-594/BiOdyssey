using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseBuilder : MonoBehaviour {
    public CustomizeUI cui;
    public TMP_Dropdown terrainDD;
    public TMP_Dropdown colorDD;
    public TMP_Dropdown floraDD;

    private void Start() {
        Planet p = gameObject.AddComponent<Planet>();
        p.generateNavMesh = false;

        terrainDD.value = Settings.user.baseShapeIndex;
        p.shapeSettings = cui.terrains[Settings.user.baseShapeIndex].Clone();
        colorDD.value = Settings.user.baseColorIndex;
        p.colourSettings = cui.colors[Settings.user.baseColorIndex].Clone();
        floraDD.value = Settings.user.baseFloraIndex;
        p.floraSettings = cui.floras[Settings.user.baseFloraIndex].Clone();

        p.resolution = 120;
        p.shapeSettings.planetRadius = 50;
        p.floraSettings.generateFlora = true;

        p.GeneratePlanet();

        cui.planet = p;
    }
}
