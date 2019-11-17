using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {

    public string generateName(int seed)
    {
        Debug.Log(seed);
        string name;
        seed--;
        string[] planetArray = { "Gliese-", "HD ", "Kepler-", "HIP ", "SN ", "Hubble-", "PSR ", "IRAS-" };
        string[] namesArray = { "/Alpha/", "/Beta/", "/Phi/", "/Omega/", "/Theta/", "/Lambda/", "/Epsilon/", "/Sigma/", "/Kappa/", "/Delta/"};
        name = planetArray[seed / 1000000];
        seed /= 10;
        name += (seed % 100).ToString();
        seed /= 100;
        name += namesArray[seed % 10];
        name += (seed / 10).ToString();
        return name;
    }
}