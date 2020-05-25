using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour
{
    public static PlayerJumpScript instance;
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField]
    private float forceX, forceY;
    private float treshHoldX = 7f;
    private float treshHoldY = 14f;
    private bool setPower, didJump;
    private float maxForceX = 6.5f;
    private float maxForceY = 13.5f;

    private Slider powerBar;
    private float powerBarTreshHold = 10f;
    private float powerBarValue = 0f;
    private void Awake()
    {
        MakeInstance();
        Init();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Init()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();

        powerBar.minValue = powerBarValue;
        powerBar.maxValue = powerBarTreshHold;
        powerBar.value = powerBarValue;
    }

    void Update()
    {
        SetPower();
    }

    void SetPower()
    {
        if (setPower)
        {
            forceX += treshHoldX * Time.deltaTime;
            forceY += treshHoldY * Time.deltaTime;
            if (forceX > maxForceX)
            {
                forceX = maxForceX;
            }
            if (forceY > maxForceY)
            {
                forceY = maxForceY;
            }
            powerBarValue += powerBarTreshHold * Time.deltaTime;
            powerBar.value = powerBarValue;
            //CALL powerbar
        }
    }

    public void givePower(bool power)
    {
        setPower = power;
        if (!setPower)
        {
            Jump();
        }
    }

    void Jump()
    {
        body.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0;
        didJump = true;
        animator.SetBool("Jump", didJump);
        powerBarValue = 0f;
        powerBar.value = powerBarValue;
        //reduce power bar
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (didJump)
        {
            didJump = false;
            animator.SetBool("Jump", didJump);
            if (other.gameObject.tag == "Platform")
            {
                //Create new platform
            }
        }
    }
}
