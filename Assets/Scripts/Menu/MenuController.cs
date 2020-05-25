using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnJugar;
    [SerializeField]
    private Button btnAgregarUsuario;
    [SerializeField]
    private Button btnUsuarios;
    [SerializeField]
    private Button btnRegistro;
    [SerializeField]
    private InputField fieldUsuario;
    [SerializeField]
    private GameObject panelRegistro;
    [SerializeField]
    private GameObject panelUsuario;
    [SerializeField]
    private GameObject prefabUser;
    public static MenuController instance;
    public List<string> all_users = new List<string>();
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

    // Start is called before the first frame update
    void Start()
    {
        btnJugar.onClick.AddListener(() => Jugar());
        btnAgregarUsuario.onClick.AddListener(() => AgregarUsuario());
        btnUsuarios.onClick.AddListener(() => Usuarios());
        btnRegistro.onClick.AddListener(() => Registro());
        fieldUsuario.text = "";
        panelRegistro.SetActive(true);
        panelUsuario.SetActive(false);
    }

    void Jugar()
    {
        Debug.Log("Cargando Juego");
        //SceneManager.LoadScene("Game");
    }

    void AgregarUsuario()
    {
        FireBaseController.instance.AddNewUser(fieldUsuario.text);
        //Instantiate(prefabUser, Vector3.zero, Quaternion.identity);
    }

    void Usuarios()
    {
        fieldUsuario.text = "";
        FireBaseController.instance.GetAllUssers();
        panelRegistro.SetActive(false);
        panelUsuario.SetActive(true);
        CreatePrefabs();
    }

    void Registro()
    {
        panelRegistro.SetActive(true);
        panelUsuario.SetActive(false);
    }

    public void CreatePrefabs()
    {
        if (all_users.Count != 0)
        {
            for (int i = 0; i < all_users.Count; i++)
            {
                if (GameObject.Find("Panel"))
                {
                    Debug.Log("Encontrado");
                }
                GameObject actual_user = Instantiate(prefabUser, Vector3.zero, Quaternion.identity);
                Debug.Log("Create");
                actual_user.GetComponentInChildren<Text>().text = all_users[i];

                actual_user.transform.SetParent(GameObject.Find("Panel").transform);
                Vector3 velocity = Vector3.one;
                actual_user.transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 110 - (i * 25), 0), ref velocity, 0);
                actual_user.transform.localScale = Vector3.one;
            }
        }
    }

    public IEnumerator InstancePrefab()
    {
        yield return new WaitForSeconds(1.0f);

    }
}
