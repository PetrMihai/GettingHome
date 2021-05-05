using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public DatabaseReference DBreference;
    public FirebaseUser User;
    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    void Start()
    {
        int y = PlayerPrefs.GetInt("Scor");
        int x = PlayerPrefs.GetInt("Nivel");
        if(x==0)
        {
            StartCoroutine(updateScore1(y));
        }
        else if(x==1)
        {
            StartCoroutine(updateScore2(y));
        }
        else if(x==2)
        {
            StartCoroutine(updateScore3(y));
        }
        
    }
    private IEnumerator updateScore1(int score1)
    {
        string userId = PlayerPrefs.GetString("userId");
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            int x = int.Parse(snapshot.Child("score1").Value.ToString());
            if (score1 > x)
            {
                int y = int.Parse(snapshot.Child("scoref").Value.ToString());
                y -= x;
                y += score1;
                var DB1Task = DBreference.Child("users").Child(userId).Child("scoref").SetValueAsync(y);

                yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

                if (DB1Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB1Task.Exception}");
                }
                var DB2Task = DBreference.Child("users").Child(userId).Child("score1").SetValueAsync(score1);

                yield return new WaitUntil(predicate: () => DB2Task.IsCompleted);
                if (DB2Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB2Task.Exception}");
                }
            }
        }
    }
    private IEnumerator updateScore2(int score2)
    {
        string userId = PlayerPrefs.GetString("userId");
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            int x = int.Parse(snapshot.Child("score2").Value.ToString());
            if (score2 > x)
            {
                int y = int.Parse(snapshot.Child("scoref").Value.ToString());
                y -= x;
                y += score2;
                var DB1Task = DBreference.Child("users").Child(userId).Child("scoref").SetValueAsync(y);

                yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

                if (DB1Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB1Task.Exception}");
                }
                var DB2Task = DBreference.Child("users").Child(userId).Child("score2").SetValueAsync(score2);

                yield return new WaitUntil(predicate: () => DB2Task.IsCompleted);
                if (DB2Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB2Task.Exception}");
                }
            }
        }
    }
    private IEnumerator updateScore3(int score3)
    {
        string userId = PlayerPrefs.GetString("userId");
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            int x = int.Parse(snapshot.Child("score3").Value.ToString());
            if (score3 > x)
            {
                int y = int.Parse(snapshot.Child("scoref").Value.ToString());
                y -= x;
                y += score3;
                var DB1Task = DBreference.Child("users").Child(userId).Child("scoref").SetValueAsync(y);

                yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

                if (DB1Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB1Task.Exception}");
                }
                var DB2Task = DBreference.Child("users").Child(userId).Child("score3").SetValueAsync(score3);

                yield return new WaitUntil(predicate: () => DB2Task.IsCompleted);
                if (DB2Task.Exception != null)
                {
                    Debug.LogWarning(message: $"Failed to register task with {DB2Task.Exception}");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
