using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {

    int NUM_NOMBRES;
    int NUM_NUMBERS;

    public string generateName(int seed)
    {
        NUM_NOMBRES = 10;
        NUM_NUMBERS = 100000;
        Random.seed = seed;
        string[] planetArray = {"Gliese-", "HD ", "Kepler-", "HIP ", "SN ", "Hubble-", "WR ", "R ", "PSR ", "IRAS-"};
        string nombre = planetArray[Random.range(0, NUM_NOMBRES)];
        return nombre + Random.range(0, NUM_NUMBERS);
    }
}