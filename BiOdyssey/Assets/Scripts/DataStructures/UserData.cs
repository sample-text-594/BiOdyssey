using System;

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
    }
}
