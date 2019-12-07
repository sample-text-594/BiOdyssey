using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    public float speed = 1f;
    [HideInInspector]
    public PlayerController target;
    Transform monster;

    private void Start() {
        monster = transform.GetChild(0);
    }

    void Update() {
        if (Quaternion.Angle(transform.rotation, target.transform.rotation) > 2) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
            monster.transform.localPosition = new Vector3(monster.transform.localPosition.x, monster.transform.localPosition.y, target.player.localPosition.z);
        } else {

        }
    }
}
