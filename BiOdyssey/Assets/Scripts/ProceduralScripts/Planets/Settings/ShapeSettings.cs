using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objeto que almacena los datos necesarios para generar el terreno del planeta
[CreateAssetMenu]
public class ShapeSettings : ScriptableObject {
    public float planetRadius = 1;
    public NoiseLayer[] noiseLayers;

    //Devuelve un nuevo objeto copia del invocante
    public ShapeSettings Clone() {
        ShapeSettings newSS = CreateInstance<ShapeSettings>();

        newSS.noiseLayers = new NoiseLayer[this.noiseLayers.Length];
        for (int i = 0; i < newSS.noiseLayers.Length; i++) {
            newSS.noiseLayers[i] = new NoiseLayer();
            newSS.noiseLayers[i].enabled = this.noiseLayers[i].enabled;
            newSS.noiseLayers[i].useFirstLayerAsMask = this.noiseLayers[i].useFirstLayerAsMask;

            newSS.noiseLayers[i].noiseSettings = new NoiseSettings();
            newSS.noiseLayers[i].noiseSettings.filterType = this.noiseLayers[i].noiseSettings.filterType;

            switch (newSS.noiseLayers[i].noiseSettings.filterType) {
                case NoiseSettings.FilterType.Simple:
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings = new NoiseSettings.SimpleNoiseSettings();

                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.strength = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.strength;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.numLayers = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.numLayers;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.baseRoughness = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.baseRoughness;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.roughness = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.roughness;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.persistance = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.persistance;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.centre = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.centre;
                    newSS.noiseLayers[i].noiseSettings.simpleNoiseSettings.minValue = this.noiseLayers[i].noiseSettings.simpleNoiseSettings.minValue;
                    break;
                case NoiseSettings.FilterType.Rigid:
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings = new NoiseSettings.RigidNoiseSettings();

                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.strength = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.strength;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.numLayers = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.numLayers;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.baseRoughness = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.baseRoughness;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.roughness = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.roughness;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.persistance = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.persistance;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.centre = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.centre;
                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.minValue = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.minValue;

                    newSS.noiseLayers[i].noiseSettings.rigidNoiseSettings.weightMultiplier = this.noiseLayers[i].noiseSettings.rigidNoiseSettings.weightMultiplier;
                    break;
                case NoiseSettings.FilterType.Flat:
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings = new NoiseSettings.FlatNoiseSettings();

                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.strength = this.noiseLayers[i].noiseSettings.flatNoiseSettings.strength;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.numLayers = this.noiseLayers[i].noiseSettings.flatNoiseSettings.numLayers;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.baseRoughness = this.noiseLayers[i].noiseSettings.flatNoiseSettings.baseRoughness;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.roughness = this.noiseLayers[i].noiseSettings.flatNoiseSettings.roughness;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.persistance = this.noiseLayers[i].noiseSettings.flatNoiseSettings.persistance;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.centre = this.noiseLayers[i].noiseSettings.flatNoiseSettings.centre;
                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.minValue = this.noiseLayers[i].noiseSettings.flatNoiseSettings.minValue;

                    newSS.noiseLayers[i].noiseSettings.flatNoiseSettings.flatness = this.noiseLayers[i].noiseSettings.flatNoiseSettings.flatness;
                    break;
            }
        }

        return newSS;
    }

    [System.Serializable]
    public class NoiseLayer {
        public bool enabled = true;
        public bool useFirstLayerAsMask;
        public NoiseSettings noiseSettings;
    }
}
