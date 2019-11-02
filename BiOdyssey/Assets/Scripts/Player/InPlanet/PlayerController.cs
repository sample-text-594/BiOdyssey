using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public float verticalSpeed = 1f;
    public float baseElevation = 2.5f;
    public float elevationMargin = 0.5f;

    int layerMask;

    Transform player;
    float planetRadius;

    void Start() {
        player = transform.GetChild(0);
        planetRadius = GameObject.Find("Planet").GetComponent<Planet>().shapeSettings.planetRadius;

        player.localPosition = new Vector3(0.0f, 0.0f, -planetRadius - baseElevation);
        layerMask = 1 << 8;
    }
    
    void Update() {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        if (vAxis != 0.0f) {
            transform.Rotate(new Vector3 (0.0f, -vAxis * movementSpeed * Time.deltaTime, 0.0f));
        }

        if (hAxis != 0.0f) {
            transform.Rotate(new Vector3(0.0f, 0.0f, -hAxis * rotationSpeed * Time.deltaTime));
        }

        RaycastHit hit;
        if (Physics.Raycast(player.position, -player.up, out hit, baseElevation + elevationMargin, layerMask)) {
            if (hit.distance < baseElevation) {
                player.localPosition = new Vector3(0.0f, 0.0f, player.localPosition.z - 0.1f * verticalSpeed * Time.deltaTime);
            }
        } else {
            player.localPosition = new Vector3(0.0f, 0.0f, player.localPosition.z + 0.1f * verticalSpeed * Time.deltaTime);
        }
    }
}
