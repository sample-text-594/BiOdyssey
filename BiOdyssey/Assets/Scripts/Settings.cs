﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {
    public static int seed = -1;
    public static PlanetSettings planetSettings = (PlanetSettings) ScriptableObject.CreateInstance("PlanetSettings");
    public static float fuel = 1;
}