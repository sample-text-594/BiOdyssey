using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject star;
    int numPlanets;
    public Mesh mesh;
    public Gradient grad;
    float[] RotationSpeedArray;
    float[] OrbitDegreesArray;
    float[] distancesArray;
    Transform[] transformArray;
    string systemName;

    // Start is called before the first frame update
    void Start()
    {
        systemName = generateName();
        star.name = systemName;
        float scale = Random.Range(1, 101) / 10.0f;
        transform.localScale = new Vector3(scale, scale, scale);
        GetComponent<Light>().color = grad.Evaluate(scale/10);
        numPlanets = Random.Range(3, 6);
        transformArray = new Transform[numPlanets];
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
            string name = systemName;
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
            GameObject planetoid = new GameObject(name);
            planetoid.transform.SetParent(transform);
            planetoid.AddComponent<MeshRenderer>();
            MeshFilter filter = planetoid.AddComponent<MeshFilter>();
            filter.sharedMesh = mesh;
            transformArray[i] = planetoid.transform;
            transformArray[i].localPosition = new Vector3(0.0f, 0.0f, distancesArray[i]);
            OrbitDegreesArray[i] = 50/distancesArray[i] + Random.Range(0, 5);
            RotationSpeedArray[i] = Random.Range(0, 101);
            float planetScale = 0.2f + (Random.Range(0, 9) / 20.0f);
            transformArray[i].localScale = new Vector3 (planetScale, planetScale, planetScale);
            planetoid.AddComponent<GoToPlanet>();
            planetoid.AddComponent<BoxCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< numPlanets; i++){
            transformArray[i].Rotate(Vector3.up, RotationSpeedArray[i] * Time.deltaTime);
            transformArray[i].RotateAround(transform.position, Vector3.up, OrbitDegreesArray[i] * Time.deltaTime);  
        }
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