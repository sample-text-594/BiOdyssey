using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que hace que los elementos orbiten
public class Orbit : MonoBehaviour {
    public float orbitSpeed = 1;

    Vector3 axis;
    void Start() {
        axis = new Vector3(Random.Range(-100, 101) / 100f, Random.Range(-100, 101) / 100f, Random.Range(-100, 101) / 100f).normalized;
    }

    void Update() {
        if (!Settings.onMobile) {
            transform.Rotate(axis, orbitSpeed * Time.deltaTime);
        }
    }
}
