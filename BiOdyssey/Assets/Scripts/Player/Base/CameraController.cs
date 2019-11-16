using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform originalTransform;
    public Transform gasolineraViewTransform;
    public Transform tallerViewTransform;
    public float animationDuration = 2f;

    public GameObject uiPlanet;
    public GameObject uiGasolinera;
    public GameObject uiTaller;

    public float dragSpeed = 1;

    Vector3 initAnimPos;
    Quaternion initAnimRot;
    Transform endAnim;

    bool animate;
    bool uiPlanetEnabled;
    bool uiGasolineraEnabled;
    bool uiTallerEnabled;

    [HideInInspector]
    public bool canRotate;
    [HideInInspector]
    public bool canInteract;

    float startTime;

    void Start() {
        animate = false;
        uiPlanetEnabled = true;
        uiGasolineraEnabled = false;
        uiTallerEnabled = false;

        canRotate = true;
        canInteract = true;
    }

    void Update() {
        if (Input.GetMouseButton(0) && canRotate) {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            transform.RotateAround(new Vector3(0f, 0f, 0f), transform.up, horizontal * dragSpeed * Time.deltaTime);
            transform.RotateAround(new Vector3(0f, 0f, 0f), transform.right, -vertical * dragSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0) && canInteract) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.layer == 9) {
                    uiPlanet.SetActive(false);
                    uiPlanetEnabled = false;

                    transform.SetParent(hit.collider.transform);
                    if (hit.collider.name.Equals("GasStation")) {
                        uiGasolineraEnabled = true;
                        StartAnimation(transform, gasolineraViewTransform);
                    } else {
                        uiTallerEnabled = true;
                        StartAnimation(transform, tallerViewTransform);
                    }

                    canRotate = false;
                    canInteract = false;
                }
            }
        }

        if (animate) {
            Animate();
        }
    }

    private void StartAnimation(Transform start, Transform end) {
        initAnimPos = start.localPosition;
        initAnimRot = start.localRotation;
        endAnim = end;
        startTime = Time.time;
        animate = true;
    }

    private void Animate() {
        if ((Time.time - startTime) >= animationDuration) {
            transform.localPosition = endAnim.localPosition;
            transform.localEulerAngles = endAnim.localEulerAngles;
            animate = false;

            if (uiPlanetEnabled != uiPlanet.activeSelf) {
                uiPlanet.SetActive(uiPlanetEnabled);

                canRotate = true;
                canInteract = true;
            }

            if (uiGasolineraEnabled != uiGasolinera.activeSelf) {
                uiGasolinera.SetActive(uiGasolineraEnabled);
            }

            if (uiTallerEnabled != uiTaller.activeSelf) {
                uiTaller.SetActive(uiTallerEnabled);
            }
        } else {
            transform.localPosition = Vector3.Lerp(initAnimPos, endAnim.localPosition, (Time.time - startTime) / animationDuration);
            transform.localRotation = Quaternion.Lerp(initAnimRot, endAnim.localRotation, (Time.time - startTime) / animationDuration);
        }
    }

    public void Return() {
        transform.SetParent(null);

        if (uiGasolineraEnabled) {
            uiGasolineraEnabled = false;
            uiGasolinera.SetActive(false);
        }

        if (uiTallerEnabled) {
            uiTallerEnabled = false;
            uiTaller.SetActive(false);
        }

        uiPlanetEnabled = true;

        StartAnimation(transform, originalTransform);
    }
}
