using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.givePower(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.givePower(false);
        }
    }
}
