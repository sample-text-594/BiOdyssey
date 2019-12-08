using System;

//Estructura de datos que controla los datos del usuario y su planeta base.

[Serializable]
public class UserData {
    public string username;
    public string password;
    public bool spanish;
    public int quality;
    public int volume;
    public int baseShapeIndex;
    public int baseColorIndex;
    public int baseFloraIndex;

    public UserData() {
        username = "";
        spanish = false;
        baseShapeIndex = 0;
        baseColorIndex = 0;
        baseFloraIndex = 0;

        quality = 60;
        volume = 5;
    }
}
