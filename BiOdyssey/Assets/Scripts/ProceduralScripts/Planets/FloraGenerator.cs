using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraGenerator {
    FloraSettings settings;
    MeshFilter[] meshFilters;
    GameObject flora;

    bool updateNeeded;

    public void UpdateSettings(FloraSettings settings, Transform t) {
        this.settings = settings;

        if (flora == null) {
            flora = new GameObject("flora");
            flora.transform.parent = t;
        }

        if (meshFilters == null || meshFilters.Length != settings.treesPerFace * 6) {
            if (meshFilters != null) {
                foreach (MeshFilter m in meshFilters) {
                    if (m != null) {
                        GameObject.DestroyImmediate(m.gameObject);
                    }
                }
            }

            meshFilters = new MeshFilter[settings.treesPerFace * 6];

            for (int i = 0; i < meshFilters.Length; i++) {
                if (meshFilters[i] == null) {
                    GameObject meshObj = new GameObject("tree");
                    meshObj.transform.parent = flora.transform;

                    meshObj.AddComponent<MeshRenderer>();
                    meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = settings.treeMesh;

                    meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = settings.treeMaterial;
                }
            }

            updateNeeded = true;
        } else {
            updateNeeded = false;
        }
    }

    public void UpdateFlora(TerrainFace[] faces, float waterHeight) {
        if (!updateNeeded) {
            return;
        }

        int index = 0;
        foreach (TerrainFace face in faces) {
            for (int i = 0; i < meshFilters.Length / 6; i++) {
                int x = Random.Range(0, face.GetResolution());
                int y = Random.Range(0, face.GetResolution());
                
                if (face.GetHeight(x, y) > waterHeight + 0.1f) {
                    if (meshFilters[index] == null) {
                        GameObject meshObj = new GameObject("tree");
                        meshObj.transform.parent = flora.transform;

                        meshObj.AddComponent<MeshRenderer>();
                        meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                        meshFilters[i].sharedMesh = settings.treeMesh;
                    }

                    meshFilters[index].transform.up = face.GetUp(x, y);
                    meshFilters[index].transform.Translate(meshFilters[index].transform.up * face.GetHeight(x, y), Space.World);
                } else {
                    GameObject.DestroyImmediate(meshFilters[index].gameObject);
                    meshFilters[index] = null;
                }
                index++;
            }
        }
    }
}
