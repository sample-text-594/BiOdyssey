using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlanetStruct {
    public string[] creatures;
    public string[] creatureNames;
    public string[] userName;
}

public struct SystemStruct {
    public int seed;
    public string name;
    public string userName;
    public PlanetStruct[] planets;
}

public class Settings {
    public static SystemStruct system;
    public static PlanetSettings planetSettings = (PlanetSettings) ScriptableObject.CreateInstance("PlanetSettings");
    public static float fuel = 1;
    public static int actualPlanet;
    public static bool returningFromPlanet = false;

    public static bool shipRepairing = false;
    public static bool shipRefilling = false;
    public static int timeLeftRepair = 0;
    public static int timeLeftFill = 0;
}