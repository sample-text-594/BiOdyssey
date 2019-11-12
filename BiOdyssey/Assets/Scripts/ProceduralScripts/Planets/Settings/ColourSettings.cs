using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColourSettings : ScriptableObject {
    public Gradient gradient;
    public Gradient oceanColour;
    public Material planetMaterial;

    public Texture2D oceanTexture;
    public int oceanTextureScale;

    public Texture2D terrainTexture;
    public int terrainTextureScale;

    public ColourSettings Clone() {
        ColourSettings newCS = CreateInstance<ColourSettings>();

        newCS.gradient = this.gradient;
        newCS.oceanColour = this.oceanColour;
        newCS.planetMaterial = this.planetMaterial;

        newCS.oceanTexture = this.oceanTexture;
        newCS.oceanTextureScale = this.oceanTextureScale;

        newCS.terrainTexture = this.terrainTexture;
        newCS.terrainTextureScale = this.terrainTextureScale;

        return newCS;
    }
}
