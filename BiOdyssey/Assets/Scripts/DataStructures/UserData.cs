using System;

[Serializable]
public class UserData {
    public string username;
    public string password;
    public int baseShapeIndex;
    public int baseColorIndex;
    public int baseFloraIndex;

    public UserData() {
        username = "";
        baseShapeIndex = 0;
        baseColorIndex = 0;
        baseFloraIndex = 0;
    }
}
