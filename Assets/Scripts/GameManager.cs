using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instane;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platform;
    private float minX = -2.5f, maxX = 2.5f, minY = -0.7f, maxY = 0.7f;
    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;
    private void Awake()
    {
        MakeInstance();
        CreateInitialPlatform();
    }

    void MakeInstance()
    {
        if (instane == null)
        {
            instane = this;
        }
    }
    void CreateInitialPlatform()
    {
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0f);
        Instantiate(platform, temp, Quaternion.identity);

        temp.y += 2f;
        Instantiate(player, temp, Quaternion.identity);

        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0f);
        Instantiate(platform, temp, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
