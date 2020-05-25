using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class FireBaseController : MonoBehaviour
{
    public static FireBaseController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            FirebaseDB.init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        //Listeners that get alterations in database
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
        MenuController.instance.all_users.Add(args.Snapshot.Child("fullname").ToString());
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

    public void AddNewUser(string full_name)
    {
        //SystemInfo.deviceUniqueIdentifier
        User user = new User(full_name, (Random.Range(100000, 999999)).ToString(), "aloha@gmail.com");
        string json = JsonUtility.ToJson(user);
        //Set
        FirebaseDB.reference.Child("users").Child(user.id).SetRawJsonValueAsync(json);
    }

    public void GetAllUssers()
    {
        List<string> temp = new List<string>();
        FirebaseDB.reference.Child("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log("No actual users");
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;
                /*foreach (var item in snapshot.Children)
                {
                    Debug.Log(item.Child("fullname").ToString());
                    MenuController.instance.all_users.Add(item.Child("fullname").ToString());
                }
                StartCoroutine(MenuController.instance.InstancePrefab());
                Debug.Log("Creados");*/
                // Do something with snapshot...
            }
        });
    }
}
