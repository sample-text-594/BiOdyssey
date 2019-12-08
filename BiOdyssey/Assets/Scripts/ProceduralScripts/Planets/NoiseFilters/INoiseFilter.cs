using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de los filtros de ruido
public interface INoiseFilter {
    float Evaluate(Vector3 point);
}
