using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateWander : IStatesCreature {

    //Atributo de velocidad.
    public int speed = 1;
    Vector3 dest;

    public IStatesCreature Update(CreatureController c) {

        if (c.agent.remainingDistance == 0) {
            foreach (Animator anim in c.anims) {
                anim.SetBool("isWalking", false);
            }
        } else {
            foreach (Animator anim in c.anims) {
                anim.SetBool("isWalking", true);
            }
        }
        
        c.agent.speed = speed;

        //Nuevo destino aleatorio.
        int rand = Random.Range(0, 1000);
        if(rand > 995) {

            //Si es un bicho de Sandra usamos sus valores de altura
            if(c.GetComponentsInChildren<Transform>().Length == 5) {

                //Si no está en el agua...
                if(Vector3.Distance(c.transform.position, Vector3.zero) > 50.7) {
                    //...Destino aleatorio, si va al agua no se ejecuta, si va hacia tierra fija ese destino.
                    dest = c.transform.position + new Vector3((Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10);
                    if (Vector3.Distance(dest, Vector3.zero) < 50.7) {
                        return c.wanderState;
                    } else {
                        c.agent.destination = dest;
                    }
                    //Si está en el agua hace lo mismo buscando tierra para ir rapidamente.
                } else {
                    dest = c.transform.position + new Vector3((Random.value - 0.5f) * 1000, (Random.value - 0.5f) * 1000, (Random.value - 0.5f) * 1000);
                    if (Vector3.Distance(dest, Vector3.zero) < 50.7) {
                        return c.wanderState;
                    } else {
                        c.agent.destination = dest;
                    }
                }

            //Lo mismo con las de Kyke
            } else {
                if (Vector3.Distance(c.transform.position, Vector3.zero) > 50.1) {
                    dest = c.transform.position + new Vector3((Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10, (Random.value - 0.5f) * 10);
                    if (Vector3.Distance(dest, Vector3.zero) < 50.1) {
                        return c.wanderState;
                    } else {
                        c.agent.destination = dest;
                    }
                } else {
                    dest = c.transform.position + new Vector3((Random.value - 0.5f) * 1000, (Random.value - 0.5f) * 1000, (Random.value - 0.5f) * 1000);
                    if (Vector3.Distance(dest, Vector3.zero) < 50.1) {
                        return c.wanderState;
                    } else {
                        c.agent.destination = dest;
                    }
                }
            }
        }
        return c.wanderState;
    }
}
