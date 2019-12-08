using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controlador de la IA del monstruo enemigo.
public class MonsterController : MonoBehaviour {

    //Atributos
    public float speed = 1f;
    public AudioClip mainMenuMusic;
 
    [HideInInspector]
    public PlayerController target;
    [HideInInspector]
    public SceneLoader sl;

    Transform monster;
    Animator monsterAnimator;

    //Coge la posición propia y su animator.
    private void Start() {
        monster = transform.GetChild(0);
        monsterAnimator = monster.GetComponent<Animator>();
    }

    void Update() {
        //En caso de estar lejos, te persigue.
        if (Quaternion.Angle(transform.rotation, target.transform.rotation) > 2) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
            monster.localPosition = new Vector3(monster.localPosition.x, monster.localPosition.y, target.player.localPosition.z);

            Vector3 point = target.player.transform.position - monster.position;
            point.y = 0;
            monster.forward = point.normalized;

            monster.localEulerAngles = new Vector3(monster.localEulerAngles.x, monster.localEulerAngles.y, 90);

        //Si está en rango, te ataca y acabas fuera del planeta.
        } else {
            monsterAnimator.SetBool("attack", true);
            if (monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("End")) {
                DatabaseHandler.PostSystem(Settings.system, () => {
                    AudioSource musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
                    musicManager.clip = mainMenuMusic;
                    musicManager.Play();

                    Settings.fuel = 1;
                    Settings.energyCellsBroken = 0;
                    Settings.returningFromPlanet = false;

                    sl.LoadScene();
                });
            }
        }
    }
}
