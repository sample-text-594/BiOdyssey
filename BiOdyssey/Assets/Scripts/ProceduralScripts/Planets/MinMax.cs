using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que ayuda a mantener un registro del punto mas bajo y alto del planeta
public class MinMax {
    public float Min { get; private set; }
    public float Max { get; private set; }

    public MinMax() {
        Min = float.MaxValue;
        Max = float.MinValue;
    }

    public void AddValue(float v) {
        if (v > Max) {
            Max = v;
        }

        if (v < Min) {
            Min = v;
        }
    }
}
