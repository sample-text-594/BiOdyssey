using System;

[Serializable]
public class PlanetData {
    public string[] creatures;
    public string[] creatureNames;
    public string[] userNames;

    public PlanetData() {
        creatures = new string[3];
        creatureNames = new string[3];
        userNames = new string[3];

        for (int i = 0; i < creatures.Length; i++) {
            creatures[i] = "";
            creatureNames[i] = "";
            userNames[i] = "";
        }
    }
}
