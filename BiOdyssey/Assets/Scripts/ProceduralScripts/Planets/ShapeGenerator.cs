using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator {
    ShapeSettings settings;
    INoiseFilter[] noiseFilters;
    public MinMax elevationMinMax;

    public void UpdateSettings(ShapeSettings settings) {
        this.settings = settings;
        noiseFilters = new INoiseFilter[settings.noiseLayers.Length];

        for (int i = 0; i < noiseFilters.Length; i++) {
            noiseFilters[i] = NoiseFilterFactory.CreateNoiseFilter(settings.noiseLayers[i].noiseSettings);
        }

        elevationMinMax = new MinMax();
    }

    public float CalculateUnscaledElevation(Vector3 pointOnUnitSphere) {
        float firstLayerValue = 0;
        float elevation = 0;

        //Evaluamos el punto en la primera capa de ruido
        if (noiseFilters.Length > 0) {
            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSphere);
            if (settings.noiseLayers[0].enabled) {
                elevation = firstLayerValue;
            }
        }

        //Evaluamos el punto en las capas de ruido restantes con la opcion de usar la primera como mascara
        for (int i = 1; i < noiseFilters.Length; i++) {
            if (settings.noiseLayers[i].enabled) {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 1;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }
        
        //Actualizamos el MinMax
        elevationMinMax.AddValue(elevation);
        return elevation;
    }

    //Funcion que devuelve el punto escalado
    public float GetScaledElevation(float unscaledElevation) {
        float elevation = Mathf.Max(0, unscaledElevation);
        elevation = settings.planetRadius * (1 + elevation);
        return elevation;
    }
}
