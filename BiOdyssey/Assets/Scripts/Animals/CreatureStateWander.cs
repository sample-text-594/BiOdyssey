using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateWander : IStatesCreature {

    //Atributo de velocidad.
    public int speed = 3;

    public IStatesCreature Update(CreatureController c) {

        c.agent.speed = speed;

        //Nuevo destino aleatorio.
        int rand = Random.Range(0, 100);
        if(rand > 79) {
            c.agent.destination = c.transform.position + new Vector3((Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80, (Random.value - 0.5f) * 80);
        }
        return c.wanderState;
    }
}
