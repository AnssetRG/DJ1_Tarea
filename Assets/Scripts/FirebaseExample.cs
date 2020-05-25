using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class FirebaseExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseDB.init();
        User user = new User("Jose", SystemInfo.deviceUniqueIdentifier, "aloha@gmail.com");
        string json = JsonUtility.ToJson(user);
        //Set
        //FirebaseDB.reference.Child("users").Child(user.id).SetRawJsonValueAsync(json);

        //Get
        FirebaseDB.reference.Child("users").ChildAdded += HandleChildAdded;
        FirebaseDB.reference.Child("users").ChildChanged += HandleChildChanged;
        FirebaseDB.reference.Child("users").ChildRemoved += HandleChildRemoved;
    }
    void HandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("Added: " + args.Snapshot);
    }
    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("Changed: " + args.Snapshot);
    }
    void HandleChildRemoved(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("Removed: " + args.Snapshot);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
