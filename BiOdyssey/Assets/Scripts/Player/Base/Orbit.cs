using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    public float orbitSpeed = 1;

    Vector3 axis;
    void Start() {
        axis = new Vector3(Random.Range(-100, 101) / 100f, Random.Range(-100, 101) / 100f, Random.Range(-100, 101) / 100f).normalized;
    }

    void Update() {
        transform.Rotate(axis, orbitSpeed * Time.deltaTime);
    }
}
