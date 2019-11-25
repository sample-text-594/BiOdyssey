using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour {

    IStatesCreature state;

    [HideInInspector]
    public CreatureStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {
        state = wanderState;
    }

    // Update is called once per frame
    void Update() {
        state = state.Update(this);
    }
}