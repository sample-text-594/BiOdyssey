using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz de la máquina de estados de la IA de las criaturas.
public interface IStatesCreature {
    IStatesCreature Update(CreatureController o);
}