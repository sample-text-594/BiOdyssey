using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Controlador de la máquina de estados de las criaturas.
public class CreatureController : MonoBehaviour {

    IStatesCreature state;

    [HideInInspector]
    public Animator[] anims;

    [HideInInspector]
    public CreatureStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {

        //Coge los animators de las 5/6 partes que componen cada criatura.
        anims = GetComponentsInChildren<Animator>();
        wanderState = new CreatureStateWander();
        state = wanderState;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        state = state.Update(this);
    }
}