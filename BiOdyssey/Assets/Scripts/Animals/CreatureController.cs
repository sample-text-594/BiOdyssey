using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureController : MonoBehaviour {

    IStatesCreature state;

    [HideInInspector]
    public Animator[] anims;

    [HideInInspector]
    public CreatureStateWander wanderState;

    [HideInInspector]
    public NavMeshAgent agent;

    void Start() {

        anims = GetComponentsInChildren<Animator>();
        wanderState = new CreatureStateWander();
        state = wanderState;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        state = state.Update(this);
    }
}