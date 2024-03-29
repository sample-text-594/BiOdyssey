﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que controla la estrella, su color, tamaño, etc.
public class Star : MonoBehaviour
{
    public Mesh mesh;
    public Gradient grad;
    public PlanetSettings[] planetSettings;
    public Transform cameraReference;
    public DiscoverSystem ds;
    public GoToPlanet gtp;

    public Material starMaterial;

    NameGenerator nameGenerator;

    int numPlanets;
    float[] RotationSpeedArray;
    float[] OrbitDegreesArray;
    float[] distancesArray;
    Transform[] planetoidTransformArray;
    Transform[] planetTransformArray;

    Color sunLightColor;

    void Start() {

        //Al arrancar el sistema con una seed aleatoria
        Random.InitState(Settings.system.seed);

        //Genera el nombre si no está ya renombrado por un usuario
        if (Settings.system.name.Equals("")) {
            nameGenerator = new NameGenerator();
            gameObject.name = nameGenerator.generateName(Settings.system.seed);
        } else {
            gameObject.name = Settings.system.name;
        }
        
        //Tamaño aleatorio de la estrella
        float scale = Random.Range(10, 101) / 10.0f;

        //La cámara se adecúa a ese tamaño
        Camera.main.transform.position = new Vector3 (0, 26 + 20 * scale, -26 -20 * scale);
        cameraReference.position = new Vector3(0, 26 + 20 * scale, -26 - 20 * scale);

        //El color de la estrella y de la luz que emite depende del tamaño
        transform.localScale = new Vector3(scale, scale, scale);
        sunLightColor = grad.Evaluate(scale/10);

        starMaterial.SetColor("_EmissionColor", sunLightColor);

        //Genera los planetas existentes...
        numPlanets = Random.Range(3, 6);
        planetoidTransformArray = new Transform[numPlanets];
        planetTransformArray = new Transform[numPlanets];
        OrbitDegreesArray = new float[numPlanets];
        distancesArray = new float[numPlanets];
        RotationSpeedArray = new float[numPlanets];

        //...Y los coloca en escena orbitando la estrella
        for (int i = 0; i < numPlanets; i++)
        {
            if (i != 0)
            {
                distancesArray[i] = Random.Range(5, 10) + distancesArray[i - 1];
            } else
            {
                distancesArray[i] = Random.Range(5, 10) + scale/4;
            }
            string name = gameObject.name;
            //Nombres de los planetas en función del nombre del sistema
            switch (i)
            {
                case 0:
                    name += "-b";
                    break;
                case 1:
                    name += "-c";
                    break;
                case 2:
                    name += "-d";
                    break;
                case 3:
                    name += "-e";
                    break;
                case 4:
                    name += "-f";
                    break;
            }

            //Tamaño de los planetas
            float size = Random.Range(10, 101) / 10.0f;

            //Genera los planetas
            GameObject planetoid = new GameObject(name);
            planetoid.transform.SetParent(transform);
            planetoid.transform.localScale = new Vector3(size, size, size);

            GameObject planet = new GameObject(name);
            planet.transform.SetParent(planetoid.transform);
            planet.layer = i + 20;

            //Sus luces
            GameObject sunLight = new GameObject("sunLight");
            sunLight.transform.SetParent(planet.transform);

            sunLight.transform.localPosition = new Vector3(0f, 0f, -4f);

            Light l = sunLight.AddComponent<Light>();
            l.color = sunLightColor;
            l.range = 20f;
            l.intensity = 5f;
            l.cullingMask = 1 << (i + 20);

            sunLight.transform.SetParent(planetoid.transform);

            //Luz de efecto ambiental para la cara oculta
            GameObject moonLight = new GameObject("moonLight");
            moonLight.transform.SetParent(planet.transform);

            moonLight.transform.localPosition = new Vector3(0f, 0f, 4f);
            moonLight.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

            l = moonLight.AddComponent<Light>();
            l.range = 20f;
            l.intensity = 0.5f;
            l.cullingMask = 1 << (i + 20);

            moonLight.transform.SetParent(planetoid.transform);

            //Se le añade el script a cada planeta y se genera con sus settings
            Planet p = planet.AddComponent<Planet>();
            int randPlanet = Random.Range(0, planetSettings.Length);

            p.resolution = 40;
            p.generateNavMesh = false;
            p.tag = planetSettings[randPlanet].tag;
            p.shapeSettings = planetSettings[randPlanet].shapeSettings.Clone();
            p.colourSettings = planetSettings[randPlanet].colourSettings.Clone();
            p.floraSettings = planetSettings[randPlanet].floraSettings.Clone();
            p.floraSettings.generateFlora = false;

            p.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre = new Vector3(Settings.system.seed * 10 + i, Settings.system.seed * 10 + i, Settings.system.seed * 10 + i);

            p.GeneratePlanet();

            planetoidTransformArray[i] = planetoid.transform;
            planetoidTransformArray[i].localPosition = new Vector3(0.0f, 0.0f, distancesArray[i]);
            planetTransformArray[i] = planet.transform;

            OrbitDegreesArray[i] = 50/distancesArray[i] + Random.Range(0, 5);
            RotationSpeedArray[i] = Random.Range(0, 101);
            
            planet.AddComponent<BoxCollider>().size = new Vector3(5f, 5f, 5f);
        }

        gtp.GtpStart();
        ds.DiscoverStar();
        if (Settings.returningFromPlanet) {
            ds.Skip();
        }
    }
    
    //Cada frame cambia la posición
    void Update()
    {
        for(int i = 0; i< numPlanets; i++){
            planetTransformArray[i].Rotate(Vector3.up, RotationSpeedArray[i] * Time.deltaTime);
            planetoidTransformArray[i].RotateAround(transform.position, Vector3.up, OrbitDegreesArray[i] * Time.deltaTime);  
        }
    }

    //Botones de viaje de la cámara entre planetas
    public string GetFirstPlanetName() {
        return planetoidTransformArray[0].name;
    }

    public string GetLastPlanetName() {
        return planetoidTransformArray[planetoidTransformArray.Length - 1].name;
    }

    public Transform GetPrevPlanet(Transform actualPlanet) {
        for (int i = 0; i < planetTransformArray.Length; i++) {
            if (planetTransformArray[i] == actualPlanet) {
                return planetTransformArray[i - 1];
            }
        }

        return null;
    }

    public Transform GetNextPlanet(Transform actualPlanet) {
        for (int i = 0; i < planetTransformArray.Length; i++) {
            if (planetTransformArray[i] == actualPlanet) {
                return planetTransformArray[i + 1];
            }
        }

        return null;
    }

    //Cambia los nombres de los planetas al renombrar el sistema
    public void RenameStar(string newName) {
        gameObject.name = newName;

        for (int i = 0; i < planetoidTransformArray.Length; i++) {
            switch (i) {
                case 0:
                    planetoidTransformArray[i].gameObject.name = newName + "-b";
                    planetTransformArray[i].gameObject.name = newName + "-b";
                    break;
                case 1:
                    planetoidTransformArray[i].gameObject.name = newName + "-c";
                    planetTransformArray[i].gameObject.name = newName + "-c";
                    break;
                case 2:
                    planetoidTransformArray[i].gameObject.name = newName + "-d";
                    planetTransformArray[i].gameObject.name = newName + "-d";
                    break;
                case 3:
                    planetoidTransformArray[i].gameObject.name = newName + "-e";
                    planetTransformArray[i].gameObject.name = newName + "-e";
                    break;
                case 4:
                    planetoidTransformArray[i].gameObject.name = newName + "-f";
                    planetTransformArray[i].gameObject.name = newName + "-f";
                    break;
            }
        }
    }
}