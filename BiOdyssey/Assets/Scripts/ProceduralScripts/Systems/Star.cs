using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Mesh mesh;
    public Gradient grad;
    public PlanetSettings[] planetSettings;

    NameGenerator nameGenerator;

    int seed;
    int numPlanets;
    float[] RotationSpeedArray;
    float[] OrbitDegreesArray;
    float[] distancesArray;
    Transform[] planetoidTransformArray;
    Transform[] planetTransformArray;

    Color sunLightColor;

    void Start()
    {
        seed = PlayerPrefs.GetInt("seed", -1);
        if (seed == -1) {
            seed = 1;
        }

        Random.InitState(seed);

        nameGenerator = new NameGenerator();
        gameObject.name = nameGenerator.generateName(1);
        float scale = Random.Range(1, 101) / 10.0f;
        transform.localScale = new Vector3(scale, scale, scale);
        sunLightColor = grad.Evaluate(scale/10);

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

            sunLight.transform.localPosition = new Vector3(0f, 0f, -4f);

            Light l = sunLight.AddComponent<Light>();
            l.color = sunLightColor;
            l.range = 20f;
            l.intensity = 5f;
            l.cullingMask = 1 << (i + 20);

            sunLight.transform.SetParent(planetoid.transform);

            GameObject moonLight = new GameObject("moonLight");
            moonLight.transform.SetParent(planet.transform);

            moonLight.transform.localPosition = new Vector3(0f, 0f, 4f);
            moonLight.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

            l = moonLight.AddComponent<Light>();
            l.range = 20f;
            l.intensity = 0.5f;
            l.cullingMask = 1 << (i + 20);

            moonLight.transform.SetParent(planetoid.transform);

            Planet p = planet.AddComponent<Planet>();
            int randPlanet = 0;

            p.resolution = 40;
            p.shapeSettings = planetSettings[randPlanet].shapeSettings.Clone();
            p.colourSettings = planetSettings[randPlanet].colourSettings.Clone();
            p.floraSettings = planetSettings[randPlanet].floraSettings.Clone();
            p.floraSettings.generateFlora = false;

            p.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre = new Vector3(seed * 10 + i, seed * 10 + i, seed * 10 + i);

            p.GeneratePlanet();

            planetoidTransformArray[i] = planetoid.transform;
            planetoidTransformArray[i].localPosition = new Vector3(0.0f, 0.0f, distancesArray[i]);
            planetTransformArray[i] = planet.transform;

            OrbitDegreesArray[i] = 50/distancesArray[i] + Random.Range(0, 5);
            RotationSpeedArray[i] = Random.Range(0, 101);
            
            planet.AddComponent<BoxCollider>().size = new Vector3(5f, 5f, 5f);
        }

        PlayerPrefs.SetInt("seed", ++seed);
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
}