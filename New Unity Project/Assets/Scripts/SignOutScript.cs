using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;





public class SignOutScript : MonoBehaviour
{
    public FirebaseAuth auth;
    public DependencyStatus dependencyStatus;
    public DatabaseReference DBreference;

    //User Data variables
    [Header("UserData")]
    public GameObject scoreElement;
    public Transform scoreboardContent;

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

     public void SignOutButton()
    {
        auth.SignOut();
        SceneManager.LoadScene("Login");

    }
    public void ScoreboardButton()
    {
        StartCoroutine(LoadScoreboardData());
    }
    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").OrderByChild("scoref").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string username = childSnapshot.Child("username").Value.ToString();
                int score1 = int.Parse(childSnapshot.Child("score1").Value.ToString());
                int score2 = int.Parse(childSnapshot.Child("score2").Value.ToString());
                int score3 = int.Parse(childSnapshot.Child("score3").Value.ToString());
                int scoref = int.Parse(childSnapshot.Child("scoref").Value.ToString());

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, score1, score2, score3, scoref);
            }
        }
    }
}
