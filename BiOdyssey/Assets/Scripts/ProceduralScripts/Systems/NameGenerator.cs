using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {

    const int NUM_NOMBRES = 10;
    const int NUM_NUMBERS = 100000;

    public string generateName(int seed)
    {
        string[] planetArray = {"Gliese-", "HD ", "Kepler-", "HIP ", "SN ", "Hubble-", "WR ", "R ", "PSR ", "IRAS-"};
        string nombre = planetArray[Random.Range(0, NUM_NOMBRES)];
        return nombre + Random.Range(0, NUM_NUMBERS);
    }
}