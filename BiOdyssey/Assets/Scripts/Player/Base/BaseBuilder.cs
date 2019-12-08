using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Maneja y controla los cambios que el usuario realiza en su planeta base
public class BaseBuilder : MonoBehaviour {
    public CustomizeUI cui;
    public TMP_Dropdown terrainDD;
    public TMP_Dropdown colorDD;
    public TMP_Dropdown floraDD;

    private void Start() {
        //Crea el planeta
        Planet p = gameObject.AddComponent<Planet>();
        p.generateNavMesh = false;

        //Settings del usuario
        terrainDD.value = Settings.user.baseShapeIndex;
        p.shapeSettings = cui.terrains[Settings.user.baseShapeIndex].Clone();
        colorDD.value = Settings.user.baseColorIndex;
        p.colourSettings = cui.colors[Settings.user.baseColorIndex].Clone();
        floraDD.value = Settings.user.baseFloraIndex;
        p.floraSettings = cui.floras[Settings.user.baseFloraIndex].Clone();

        p.resolution = 120;
        p.shapeSettings.planetRadius = 50;
        p.floraSettings.generateFlora = true;

        //Genera planeta
        p.GeneratePlanet();

        cui.planet = p;
    }
}
