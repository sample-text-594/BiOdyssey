using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 10;
    public bool autoUpdate = true;
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

    void Start() {
        GeneratePlanet();
    }

    void Initialize() {
        if (shapeGenerator == null) {
            shapeGenerator = new ShapeGenerator();
            colourGenerator = new ColourGenerator();
            floraGenerator = new FloraGenerator();
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
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;
                if (transform.gameObject.layer == 0) {
                    meshObj.layer = 8;
                } else {
                    meshObj.layer = transform.gameObject.layer;
                }

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
                meshObj.AddComponent<MeshCollider>();
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
}
