using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloraSettings : ScriptableObject {
    public int treesPerFace = 0;
    public Mesh treeMesh;
    public Material treeMaterial;

    public bool generateFlora = true;

    public FloraSettings Clone() {
        FloraSettings newFS = CreateInstance<FloraSettings>();

        newFS.treesPerFace = this.treesPerFace;
        newFS.treeMesh = this.treeMesh;
        newFS.treeMaterial = this.treeMaterial;
        newFS.generateFlora = this.generateFlora;

        return newFS;
    }
}
