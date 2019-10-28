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
}
