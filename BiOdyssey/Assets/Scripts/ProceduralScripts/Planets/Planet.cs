using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 10;
    public bool autoUpdate = true;
    public bool generateNavMesh = true;
    public enum FaceRenderMask { All, Top, Bottom, Left, Right, Front, Back}
    public FaceRenderMask faceRenderMask;

    public ShapeSettings shapeSettings;
    public ColourSettings colourSettings;
    public FloraSettings floraSettings;

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colourSettingsFoldout;
    [HideInInspector]
    public bool floraSettingsFoldout;

    ShapeGenerator shapeGenerator;
    ColourGenerator colourGenerator;
    FloraGenerator floraGenerator;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    GameObject[] faces;

    void Start() {
        GeneratePlanet();
    }

    void Initialize() {
        if (shapeGenerator == null) {
            shapeGenerator = new ShapeGenerator();
            colourGenerator = new ColourGenerator();
            floraGenerator = new FloraGenerator();

            faces = new GameObject[6];
        }

        shapeGenerator.UpdateSettings(shapeSettings);
        colourGenerator.UpdateSettings(colourSettings);

        if (floraSettings.generateFlora) {
            floraGenerator.UpdateSettings(floraSettings, transform);
        }

        if (meshFilters == null || meshFilters.Length == 0) {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++) {
            if (meshFilters[i] == null) {
                faces[i] = new GameObject("face");

                if (i != 0) {
                    if (i != 1) {
                        faces[i].transform.Rotate(Vector3.Cross(Vector3.up, directions[i]), 90);
                    } else {
                        faces[i].transform.Rotate(Vector3.Cross(Vector3.up, Vector3.right), 180);
                    }
                }
                faces[i].transform.parent = transform;

                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = faces[i].transform;
                if (transform.gameObject.layer == 0) {
                    meshObj.layer = 8;
                } else {
                    meshObj.layer = transform.gameObject.layer;
                }

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colourSettings.planetMaterial;

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
            bool renderFace = faceRenderMask == FaceRenderMask.All || (int)faceRenderMask - 1 == i;
            meshFilters[i].gameObject.SetActive(renderFace);
        }
    }

    public void GeneratePlanet() {
        Initialize();
        GenerateMesh();
        GenerateColours();
        GenerateFlora();
        GenerateNavMesh();
    }

    public void OnShapeSettingsUpdated() {
        if (autoUpdate) {
            Initialize();
            GenerateMesh();
        }
    }

    public void OnColourSettingsUpdated() {
        if (autoUpdate) {
            Initialize();
            GenerateColours();
        }
    }

    public void OnFloraSettingsUpdated() {
        if (autoUpdate) {
            Initialize();
            GenerateFlora();
        }
    }

    void GenerateMesh() {
        for (int i = 0; i < 6; i++) {
            if (meshFilters[i].gameObject.activeSelf) {
                terrainFaces[i].CreateMesh();
                if (!meshFilters[i].gameObject.GetComponent<MeshCollider>()) {
                    meshFilters[i].gameObject.AddComponent<MeshCollider>();
                }
            }
        }

        colourGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    void GenerateColours() {
        colourGenerator.UpdateColours();
    }

    void GenerateFlora() {
        if (floraSettings.generateFlora) {
            floraGenerator.UpdateFlora(terrainFaces, shapeSettings.planetRadius);
        }
    }

    void GenerateNavMesh() {
        if (generateNavMesh) {
            for (int i = 0; i < faces.Length; i++) {
                NavMeshSurface nms = faces[i].GetComponent<NavMeshSurface>();

                if (!nms) {
                    nms = faces[i].AddComponent<NavMeshSurface>();
                    nms.collectObjects = CollectObjects.Children;
                }

                nms.BuildNavMesh();
            }
        }
    }
}
