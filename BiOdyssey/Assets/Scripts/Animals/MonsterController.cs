using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    public float speed = 1f;

    [HideInInspector]
    public PlayerController target;
    [HideInInspector]
    public SceneLoader sl;

    Transform monster;
    Animator monsterAnimator;

    private void Start() {
        monster = transform.GetChild(0);
        monsterAnimator = monster.GetComponent<Animator>();
    }

    void Update() {
        if (Quaternion.Angle(transform.rotation, target.transform.rotation) > 2) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
            monster.localPosition = new Vector3(monster.localPosition.x, monster.localPosition.y, target.player.localPosition.z);

            Vector3 point = target.player.transform.position - monster.position;
            point.y = 0;
            monster.forward = point.normalized;

            monster.localEulerAngles = new Vector3(monster.localEulerAngles.x, monster.localEulerAngles.y, 90);
        } else {
            monsterAnimator.SetBool("attack", true);
            if (monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("End")) {
                sl.LoadScene();
            }
        }
    }
}
