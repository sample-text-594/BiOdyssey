using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script de control de la nave de exploración
public class PlayerController : MonoBehaviour {

    //Atributos
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public float verticalSpeed = 1f;
    public float baseElevation = 2.5f;
    public float elevationMargin = 0.5f;

    public float boostSpeedMultiplier = 2;
    public float boostDuration = 1;

    //Barras de energía
    public Slider[] energyBars;
    public float energyConsumeMultiplier = 1;

    //Escáner de criaturas
    public GameObject scanner;
    public float scanDuration = 1;

    public SceneLoader sl;
    public GameObject uiDiscover;
    public DiscoverCreature dc;

    public GameObject touchControls;

    int colissionLayerMask;

    float energy;
    int actualEnergyBar;

    bool boostActive;
    float boostTimeLeft;

    bool scanActive;
    float scanTimeLeft;

    [HideInInspector]
    public Transform player;
    float planetRadius;

    [HideInInspector]
    public bool poisonDamageEnabled = false;

    //Controles
    bool upArrow;
    bool downArrow;
    bool leftArrow;
    bool rightArrow;
    bool boostButton;
    bool scannerButton;

    void Start() {
        //Inicia los atributos
        player = transform.GetChild(0);
        planetRadius = GameObject.Find("Planet").GetComponent<Planet>().shapeSettings.planetRadius;

        player.localPosition = new Vector3(0.0f, 0.0f, -planetRadius - baseElevation);

        colissionLayerMask = 1 << 8;

        energy = 100;
        actualEnergyBar = energyBars.Length - 1;
        for (int i = 0; i < Settings.energyCellsBroken; i++) {
            ConsumeEnergy(20);
        }

        boostActive = false;
        boostTimeLeft = 0.0f;

        scanActive = false;
        scanTimeLeft = 0.0f;

        if (Settings.onMobile) {
            touchControls.SetActive(true);
        }

        upArrow = false;
        downArrow = false;
        leftArrow = false;
        rightArrow = false;
        boostButton = false;
        scannerButton = false;
    }
    
    void Update() {
        //Controles de la nave
        if (!uiDiscover.activeSelf) {
            float vAxis = 0;
            float hAxis = 0;
            bool scanPressed = false;
            if (!Settings.onMobile) {
                vAxis = Input.GetAxis("Vertical");
                hAxis = Input.GetAxis("Horizontal");
                scanPressed = Input.GetKeyDown(KeyCode.E);
            } else {
                if (upArrow) {
                    vAxis = 1;
                }

                if (downArrow) {
                    vAxis = -1;
                }

                if (leftArrow) {
                    hAxis = -1;
                }

                if (rightArrow) {
                    hAxis = 1;
                }

                if (scannerButton) {
                    scanPressed = true;
                }
            }
            
            //Si la energía baja a cero, sales del planeta
            if (energy < 0) {
                //Y si es un planeta venenoso, rompes una celula de la batería
                if (poisonDamageEnabled && Settings.energyCellsBroken < 4) {
                    Settings.energyCellsBroken++;
                    poisonDamageEnabled = false;
                }
                ReturnToSystem();
            }

            //Activación y desactivación del escáner
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

            //Movimientos
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

            //Consumición de energía
            ConsumeEnergy(0.1f * energyConsumeMultiplier * Time.deltaTime);

            //Boost
            if (energy > 20 && (Input.GetKeyDown(KeyCode.Space) || boostButton)) {
                boostButton = false;
                ConsumeEnergy(20);

                boostActive = true;
                boostTimeLeft = boostDuration;
            }
        }
    }

    //Método de consumición de energía
    void ConsumeEnergy(float quantity) {
        float quantityConverted = quantity / (100 / energyBars.Length);

        if (energyBars[actualEnergyBar].value > quantityConverted) {
            energyBars[actualEnergyBar].value -= quantityConverted;
        } else {
            quantityConverted -= energyBars[actualEnergyBar].value;
            energyBars[actualEnergyBar].value = 0;

            if (actualEnergyBar + Settings.energyCellsBroken > 4) {
                energyBars[actualEnergyBar].gameObject.SetActive(false);
            }

            if (actualEnergyBar > 0) {
                actualEnergyBar--;
                energyBars[actualEnergyBar].value -= quantityConverted;
            }
        }

        energy -= quantity;
    }

    //Método de vuelta al sistema
    void ReturnToSystem() {
        sl.LoadScene();
    }

    //Método que controla el escáner
    public void OnScan(Collider other) {
        if (scanActive) {
            scanner.SetActive(false);
            scanActive = false;

            if (!other.CompareTag("Combustible")) {
                int index = -1;
                for (int i = 0; i < 3; i++) {
                    string id = other.gameObject.name.Substring(0, 6);
                    if (Settings.system.planets[Settings.actualPlanet].creatures[i].Equals(id)) {
                        index = i;
                        break;
                    }
                }
                dc.Discover(index, this);
            } else {
                Settings.fuel += 0.01f;
                
                if (Settings.fuel > 1f) {
                    Settings.fuel = 1f;
                }

                Destroy(other.gameObject);
            }
            
        }
    }

    //Recarga de energía con powerups
    public void RechargeEnergy() {
        foreach (Slider s in energyBars) {
            s.value = 1;
        }
        energy = 100;
        actualEnergyBar = energyBars.Length - 1;
        for (int i = 0; i < Settings.energyCellsBroken; i++) {
            ConsumeEnergy(20);
        }
    }

    //Controles
    public void OnUpArrowDown() {
        upArrow = true;
    }

    public void OnUpArrowUp() {
        upArrow = false;
    }

    public void OnDownArrowDown() {
        downArrow = true;
    }

    public void OnDownArrowUp() {
        downArrow = false;
    }

    public void OnLeftArrowDown() {
        leftArrow = true;
    }

    public void OnLeftArrowUp() {
        leftArrow = false;
    }

    public void OnRightArrowDown() {
        rightArrow = true;
    }

    public void OnRightArrowUp() {
        rightArrow = false;
    }

    public void OnScannerButtonDown() {
        scannerButton = true;
    }

    public void OnScannerButtonUp() {
        scannerButton = false;
    }

    public void OnBoostButtonClick() {
        boostButton = true;
    }
}
