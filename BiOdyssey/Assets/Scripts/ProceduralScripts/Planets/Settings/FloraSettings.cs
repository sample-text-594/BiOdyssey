using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloraSettings : ScriptableObject {
    public int treesPerFace = 0;
    public Mesh treeMesh;
    public Material treeMaterial;
}
