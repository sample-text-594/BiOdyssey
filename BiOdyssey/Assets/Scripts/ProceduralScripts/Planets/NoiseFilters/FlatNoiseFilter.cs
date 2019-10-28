using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatNoiseFilter : INoiseFilter
{
    NoiseSettings.FlatNoiseSettings settings;
    Noise noise = new Noise();

    public FlatNoiseFilter(NoiseSettings.FlatNoiseSettings settings) {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point) {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;
        float weight = 1;

        for (int i = 0; i < settings.numLayers; i++) {
            float v = Mathf.Abs(noise.Evaluate(point * frequency + settings.centre));
            v = Mathf.Pow(v, settings.flatness);
            v *= weight;
            weight = Mathf.Clamp01(v);

            noiseValue += v * amplitude;
            frequency *= settings.roughness;
            amplitude *= settings.persistance;
        }

        noiseValue = noiseValue - settings.minValue;
        return noiseValue * settings.strength;
    }
}
