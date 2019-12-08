using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que define los ajustes de la sesión de juego, como el dispositivo, tu planeta base, o el fuel disponible.
public class Settings {
    public static bool onMobile = false;
    public static UserData user = new UserData();

    public static SystemData system = new SystemData();

    public static PlanetSettings planetSettings = (PlanetSettings) ScriptableObject.CreateInstance("PlanetSettings");
    public static int actualPlanet;

    public static float fuel = 1;
    public static int energyCellsBroken = 0;
    
    public static bool returningFromPlanet = false;

    public static bool shipRepairing = false;
    public static bool shipRefilling = false;
    public static int timeLeftRepair = 0;
    public static int timeLeftFill = 0;
}