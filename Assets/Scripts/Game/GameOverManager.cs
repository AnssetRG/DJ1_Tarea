using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Button btnRestart;
    [SerializeField]
    private Button btnQuit;
    [SerializeField]
    private GameObject panel;
    public static GameOverManager instance;
    private Animator animation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        animation = panel.GetComponent<Animator>();
        btnQuit.onClick.AddListener(() => GoMenu());
        btnRestart.onClick.AddListener(() => goRestart());
        animation.enabled = false;
    }

    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void goRestart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
        animation.enabled = true;
        animation.Play("GameOverPanel");
    }
}

