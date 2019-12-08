using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que controla la criatura, sus partes y el animator asociado a cada parte
[CreateAssetMenu]
public class Creature : ScriptableObject {
    public GameObject creaturePrefab;

    public GameObject[] part1;
    public GameObject[] part2;
    public GameObject[] part3;
    public GameObject[] part4;
    public GameObject[] part5;

    public RuntimeAnimatorController[] part1Animator;
    public RuntimeAnimatorController[] part2Animator;
    public RuntimeAnimatorController[] part3Animator;
    public RuntimeAnimatorController[] part4Animator;
    public RuntimeAnimatorController[] part5Animator;
}
