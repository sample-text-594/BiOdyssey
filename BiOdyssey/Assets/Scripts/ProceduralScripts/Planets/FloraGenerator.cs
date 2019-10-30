using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraGenerator {
    FloraSettings settings;
    MeshFilter[] meshFilters;
    GameObject flora;

    public void UpdateSettings(FloraSettings settings, Transform t) {
        this.settings = settings;

        if (meshFilters == null || meshFilters.Length != settings.treesPerFace) {
            meshFilters = new MeshFilter[settings.treesPerFace * 6];
        }

        if (flora == null) {
            flora = new GameObject("flora");
            flora.transform.parent = t;
        }

        for (int i = 0; i < meshFilters.Length; i++) {
            if (meshFilters[i] == null) {
                GameObject meshObj = new GameObject("tree");
                meshObj.transform.parent = flora.transform;

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = settings.treeMesh;
            }

            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = settings.treeMaterial;
        }
    }

    public void UpdateFlora() {
        
    }
}
