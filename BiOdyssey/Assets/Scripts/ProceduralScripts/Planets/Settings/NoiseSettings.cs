using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objeto que almacena un tipo de filtro de ruido
[System.Serializable]
public class NoiseSettings {

    public enum FilterType { Simple, Rigid, Flat };
    public FilterType filterType;

    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RigidNoiseSettings rigidNoiseSettings;
    [ConditionalHide("filterType", 2)]
    public FlatNoiseSettings flatNoiseSettings;

    [System.Serializable]
    public class SimpleNoiseSettings {
        public float strength = 1;
        [Range(1, 8)]
        public int numLayers = 1;
        public float baseRoughness = 1;
        public float roughness = 2;
        public float persistance = .5f;
        public Vector3 centre;
        public float minValue;
    }

    [System.Serializable]
    public class RigidNoiseSettings : SimpleNoiseSettings {
        public float weightMultiplier = .8f;
    }

    [System.Serializable]
    public class FlatNoiseSettings : SimpleNoiseSettings {
        public float flatness = 2f;
    }
}
