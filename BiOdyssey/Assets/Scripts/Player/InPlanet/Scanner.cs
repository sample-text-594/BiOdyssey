using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {
    public PlayerController pc;
    private void OnTriggerEnter(Collider other) {
        pc.OnScan(other);
    }
}
