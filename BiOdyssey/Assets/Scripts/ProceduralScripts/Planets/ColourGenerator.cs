using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator {
    ColourSettings settings;
    Texture2D texture;
    const int textureResolution = 50;

    public void UpdateSettings(ColourSettings settings) {
        this.settings = settings;
        if (texture == null) {
            texture = new Texture2D(textureResolution * 2, 1, TextureFormat.RGBA32, false);
        }
    }

    public void UpdateElevation(MinMax elevationMinMax) {
        settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public void UpdateColours() {
        Color[] colours = new Color[textureResolution * 2];
        for (int i = 0; i < textureResolution * 2; i++) {
            if (i < textureResolution) {
                colours[i] = settings.oceanColour.Evaluate(i / (textureResolution - 1f));
            } else {
                colours[i] = settings.gradient.Evaluate((i - textureResolution) / (textureResolution - 1f));
            }
        }
        texture.SetPixels(colours);
        texture.Apply();

        settings.planetMaterial.SetTexture("_texture", texture);

        settings.planetMaterial.SetTexture("_oceanTex", settings.oceanTexture);
        settings.planetMaterial.SetInt("_oceanTexScale", settings.oceanTextureScale);

        settings.planetMaterial.SetTexture("_terrainTex", settings.terrainTexture);
        settings.planetMaterial.SetInt("_terrainTexScale", settings.terrainTextureScale);
    }
}
