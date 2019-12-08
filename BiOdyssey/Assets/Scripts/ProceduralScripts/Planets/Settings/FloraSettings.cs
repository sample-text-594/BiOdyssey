using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objeto que almacena las opciones de generacion de la flora
[CreateAssetMenu]
public class FloraSettings : ScriptableObject {
    public int treesPerFace = 0;
    public GameObject tree;

    public bool scannable = false;
    public bool generateFlora = true;

    //Devuelve un nuevo objeto copia del invocante
    public FloraSettings Clone() {
        FloraSettings newFS = CreateInstance<FloraSettings>();

        newFS.treesPerFace = this.treesPerFace;
        newFS.tree = this.tree;
        newFS.generateFlora = this.generateFlora;
        newFS.scannable = this.scannable;

        return newFS;
    }
}
