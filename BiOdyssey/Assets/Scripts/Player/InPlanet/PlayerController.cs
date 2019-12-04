using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public float verticalSpeed = 1f;
    public float baseElevation = 2.5f;
    public float elevationMargin = 0.5f;

    public float boostSpeedMultiplier = 2;
    public float boostDuration = 1;

    public Slider[] energyBars;
    public float energyConsumeMultiplier = 1;

    public GameObject scanner;
    public float scanDuration = 1;

    public SceneLoader sl;

    int colissionLayerMask;

    public float energy;
    int actualEnergyBar;

    bool boostActive;
    float boostTimeLeft;

    bool scanActive;
    float scanTimeLeft;

    Transform player;
    float planetRadius;

    void Start() {
        player = transform.GetChild(0);
        planetRadius = GameObject.Find("Planet").GetComponent<Planet>().shapeSettings.planetRadius;

        player.localPosition = new Vector3(0.0f, 0.0f, -planetRadius - baseElevation);

        colissionLayerMask = 1 << 8;

        energy = 100;
        actualEnergyBar = energyBars.Length - 1;

        boostActive = false;
        boostTimeLeft = 0.0f;

        scanActive = false;
        scanTimeLeft = 0.0f;
    }
    
    void Update() {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        bool scanPressed = Input.GetKeyDown(KeyCode.E);

        if (energy < 0) {
            ReturnToSystem();
        }
        
        if (scanActive) {
            scanTimeLeft -= Time.deltaTime;
            if (scanTimeLeft < 0) {
                scanner.SetActive(false);
                scanActive = false;
            }
        }
        if (scanPressed && !scanActive) {
            scanner.SetActive(true);
            scanTimeLeft = scanDuration;
            scanActive = true;
        }

        if (vAxis != 0.0f) {
            if (boostActive) {
                transform.Rotate(new Vector3(0.0f, -vAxis * movementSpeed * boostSpeedMultiplier * Time.deltaTime, 0.0f));

                boostTimeLeft -= Time.deltaTime;
                if (boostTimeLeft < 0) {
                    boostActive = false;
                }
            } else {
                transform.Rotate(new Vector3(0.0f, -vAxis * movementSpeed * Time.deltaTime, 0.0f));
            }
                
        }

        if (hAxis != 0.0f) {
            transform.Rotate(new Vector3(0.0f, 0.0f, -hAxis * rotationSpeed * Time.deltaTime));
        }

        RaycastHit hit;
        if (Physics.Raycast(player.position, -player.up, out hit, baseElevation + elevationMargin, colissionLayerMask)) {
            if (hit.distance < baseElevation) {
                player.localPosition = new Vector3(0.0f, 0.0f, player.localPosition.z - 0.1f * verticalSpeed * Time.deltaTime);
            }
        } else {
            player.localPosition = new Vector3(0.0f, 0.0f, player.localPosition.z + 0.1f * verticalSpeed * Time.deltaTime);
        }

        ConsumeEnergy(0.1f * energyConsumeMultiplier * Time.deltaTime);

        if (energy > 20 && Input.GetKeyDown(KeyCode.Space)) {
            ConsumeEnergy(20);

            boostActive = true;
            boostTimeLeft = boostDuration;
        }
    }

    void ConsumeEnergy(float quantity) {
        float quantityConverted = quantity / (100 / energyBars.Length);

        if (energyBars[actualEnergyBar].value > quantityConverted) {
            energyBars[actualEnergyBar].value -= quantityConverted;
        } else {
            quantityConverted -= energyBars[actualEnergyBar].value;
            energyBars[actualEnergyBar].value = 0;
            if (actualEnergyBar > 0) {
                actualEnergyBar--;
                energyBars[actualEnergyBar].value -= quantityConverted;
            }
        }

        energy -= quantity;
    }

    void ReturnToSystem() {
        sl.LoadScene();
    }

    public void OnScan(Collider other) {
        if (scanActive) {
            Debug.Log("Escaneado");
        }
    }
}
