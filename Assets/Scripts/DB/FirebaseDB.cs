using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseDB
{
    private static string url = "https://pruebaupc01-54fbc.firebaseio.com/";
    public static DatabaseReference reference;
    public static void init()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(url);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
}
