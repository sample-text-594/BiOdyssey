using System;

[Serializable]
public class SystemData {
    public int seed;
    public string name;
    public string userName;
    public PlanetData[] planets;

    public SystemData() {
        seed = 1;
        name = "";
        userName = "";
        planets = new PlanetData[5];

        for (int i = 0; i < planets.Length; i++) {
            planets[i] = new PlanetData();
        }
    }
}
