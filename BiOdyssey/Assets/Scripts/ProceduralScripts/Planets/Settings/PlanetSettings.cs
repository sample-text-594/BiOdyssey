using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objeto que almacena lo necesario para la generacion entera de un planeta
[CreateAssetMenu]
public class PlanetSettings : ScriptableObject {
    public string tag;
    public ShapeSettings shapeSettings;
    public ColourSettings colourSettings;
    public FloraSettings floraSettings;
}
