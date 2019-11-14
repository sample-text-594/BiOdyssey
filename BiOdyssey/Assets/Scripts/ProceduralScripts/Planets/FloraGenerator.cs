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
            flora.transform.localPosition = new Vector3(0f, 0f, 0f);
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
                    GameObject meshObj = GameObject.Instantiate(settings.tree);
                    meshObj.transform.parent = flora.transform;
                    meshObj.transform.localPosition = new Vector3(0f, 0f, 0f);

                    meshFilters[i] = meshObj.GetComponent<MeshFilter>();
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
                        GameObject meshObj = GameObject.Instantiate(settings.tree);
                        meshObj.transform.parent = flora.transform;
                        meshObj.transform.localPosition = new Vector3(0f, 0f, 0f);

                        meshFilters[i] = meshObj.GetComponent<MeshFilter>();
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
