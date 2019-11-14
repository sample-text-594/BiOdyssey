using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloraSettings : ScriptableObject {
    public int treesPerFace = 0;
    public GameObject tree;
    public Material treeMaterial;

    public bool generateFlora = true;

    public FloraSettings Clone() {
        FloraSettings newFS = CreateInstance<FloraSettings>();

        newFS.treesPerFace = this.treesPerFace;
        newFS.tree = this.tree;
        newFS.treeMaterial = this.treeMaterial;
        newFS.generateFlora = this.generateFlora;

        return newFS;
    }
}
