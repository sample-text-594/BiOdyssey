using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz del pulpo.
public interface IStatesCreature {
    IStatesCreature Update(CreatureController o);
}