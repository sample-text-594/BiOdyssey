using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

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
            GameObject planetoid = new GameObject("Planet");
            planetoid.transform.SetParent(transform);
            planetoid.AddComponent<MeshRenderer>();
            MeshFilter filter = planetoid.AddComponent<MeshFilter>();
            filter.sharedMesh = mesh;
            transformArray[i] = planetoid.transform;
            transformArray[i].localPosition = new Vector3(0.0f, 0.0f, distancesArray[i]);
            OrbitDegreesArray[i] = 50/distancesArray[i] + Random.Range(0, 5);
            RotationSpeedArray[i] = Random.Range(0, 5);
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
}