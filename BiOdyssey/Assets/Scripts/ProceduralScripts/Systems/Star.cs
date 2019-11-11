﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Mesh mesh;
    public Gradient grad;
    public PlanetSettings[] planetSettings;

    int numPlanets;
    float[] RotationSpeedArray;
    float[] OrbitDegreesArray;
    float[] distancesArray;
    Transform[] planetoidTransformArray;
    Transform[] planetTransformArray;

    void Start()
    {
        gameObject.name = generateName();
        float scale = Random.Range(1, 101) / 10.0f;
        transform.localScale = new Vector3(scale, scale, scale);
        GetComponent<Light>().color = grad.Evaluate(scale/10);

        numPlanets = Random.Range(3, 6);
        planetoidTransformArray = new Transform[numPlanets];
        planetTransformArray = new Transform[numPlanets];
        OrbitDegreesArray = new float[numPlanets];
        distancesArray = new float[numPlanets];
        RotationSpeedArray = new float[numPlanets];

        for (int i = 0; i < numPlanets; i++)
        {
            if (i != 0)
            {
                distancesArray[i] = Random.Range(2, 6) + distancesArray[i - 1];
            } else
            {
                distancesArray[i] = Random.Range(1, 5) + scale/4;
            }
            string name = gameObject.name;
            switch (i)
            {
                case 0:
                    name += "b";
                    break;
                case 1:
                    name += "c";
                    break;
                case 2:
                    name += "d";
                    break;
                case 3:
                    name += "e";
                    break;
                case 4:
                    name += "f";
                    break;
            }

            float size = Random.Range(10, 101) / 10.0f;

            GameObject planetoid = new GameObject(name);
            planetoid.transform.SetParent(transform);
            planetoid.transform.localScale = new Vector3(size, size, size);

            GameObject planet = new GameObject(name);
            planet.transform.SetParent(planetoid.transform);
            planet.layer = i + 20;

            GameObject sunLight = new GameObject("sunLight");
            sunLight.transform.SetParent(planet.transform);

            sunLight.transform.localPosition = new Vector3(0f, 0f, -2f);

            Light l = sunLight.AddComponent<Light>();
            l.range = 20f;
            l.intensity = 5f;
            l.cullingMask = 1 << (i + 20);

            sunLight.transform.SetParent(planetoid.transform);

            GameObject moonLight = new GameObject("moonLight");
            moonLight.transform.SetParent(planet.transform);

            moonLight.transform.localPosition = new Vector3(0f, 0f, 2f);
            moonLight.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

            l = moonLight.AddComponent<Light>();
            l.range = 20f;
            l.intensity = 0.5f;
            l.cullingMask = 1 << (i + 20);

            moonLight.transform.SetParent(planetoid.transform);

            Planet p = planet.AddComponent<Planet>();
            int randPlanet = 0;

            p.resolution = 20;
            p.shapeSettings = planetSettings[randPlanet].shapeSettings;
            p.colourSettings = planetSettings[randPlanet].colourSettings;
            p.floraSettings = planetSettings[randPlanet].floraSettings;

            p.GeneratePlanet();

            planetoidTransformArray[i] = planetoid.transform;
            planetoidTransformArray[i].localPosition = new Vector3(0.0f, 0.0f, distancesArray[i]);
            planetTransformArray[i] = planet.transform;

            OrbitDegreesArray[i] = 50/distancesArray[i] + Random.Range(0, 5);
            RotationSpeedArray[i] = Random.Range(0, 101);
            
            planet.AddComponent<BoxCollider>();
        }
    }
    
    void Update()
    {
        for(int i = 0; i< numPlanets; i++){
            planetTransformArray[i].Rotate(Vector3.up, RotationSpeedArray[i] * Time.deltaTime);
            planetoidTransformArray[i].RotateAround(transform.position, Vector3.up, OrbitDegreesArray[i] * Time.deltaTime);  
        }
    }

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

    public string generateName()
    {
        int rand1 = Random.Range(0, 11);
        string name = "";
        switch (rand1)
        {
            case 0:
                name += "Gliese-";
                break;
            case 1:
                name += "HD ";
                break;
            case 2:
                name += "Kepler-";
                break;
            case 3:
                name += "HIP ";
                break;
            case 4:
                name += "SN ";
                break;
            case 5:
                name += "Hubble-";
                break;
            case 6:
                name += "WR ";
                break;
            case 7:
                name += "R ";
                break;
            case 8:
                name += "PSR ";
                break;
            case 9:
                name += "IRAS ";
                break;
        }
        int rand2 = Random.Range(0, 100000);
        name += rand2;
        return name;
    }
}