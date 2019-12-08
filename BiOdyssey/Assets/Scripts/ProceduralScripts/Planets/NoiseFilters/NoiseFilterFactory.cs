using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseFilterFactory {
    //Fabrica de filtros
    public static INoiseFilter CreateNoiseFilter(NoiseSettings settings) {
        switch (settings.filterType) {
            case NoiseSettings.FilterType.Simple:
                return new SimpleNoiseFilter(settings.simpleNoiseSettings);
            case NoiseSettings.FilterType.Rigid:
                return new RigidNoiseFilter(settings.rigidNoiseSettings);
            case NoiseSettings.FilterType.Flat:
                return new FlatNoiseFilter(settings.flatNoiseSettings);
        }

        return null;
    }
}
