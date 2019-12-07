using UnityEngine;
using Proyecto26;

public class DatabaseHandler {
    private const string projectId = "biodysseygame";
    private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

    public delegate void GetUserCallback(UserData user);
    public delegate void GetUserCallbackNotFound();
    public delegate void PostUserCallback();
    public delegate void GetSystemCallback(SystemData system);
    public delegate void GetSystemCallbackNotFound();
    public delegate void PostSystemCallback();

    public static void GetUser(string username, GetUserCallback callback, GetUserCallbackNotFound callbackNotFound) {
        RestClient.Get<UserData>($"{databaseURL}users/{username}.json").Then(user => {
            Debug.Log("GetUser");
            callback(user);
        }).Catch(rejected => {
            Debug.Log("GetUserRejected");
            callbackNotFound();
        });
    }

    public static void PostUser(UserData user, PostUserCallback callback) {
        RestClient.Put<UserData>($"{databaseURL}users/{user.username}.json", user).Then(response => {
            Debug.Log("PostUser");
            callback();
        });
    }

    public static void GetSystem(string systemId, GetSystemCallback callback, GetSystemCallbackNotFound callbackNotFound) {
        RestClient.Get<SystemData>($"{databaseURL}systems/{systemId}.json").Then(system => {
            Debug.Log("GetSystem");
            callback(system);
        }).Catch(rejected => {
            Debug.Log("GetSystemRejected");
            callbackNotFound();
        });
    }

    public static void PostSystem(SystemData system, PostSystemCallback callback) {
        RestClient.Put<SystemData>($"{databaseURL}systems/{system.seed}.json", system).Then(response => {
            Debug.Log("PostSystem");
            callback();
        });
    }
}
