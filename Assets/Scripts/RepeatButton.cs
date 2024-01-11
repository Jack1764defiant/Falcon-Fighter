using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RepeatButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityEvent OnClick;
    bool isPressed = false;

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
    void Update()
    {
        if (isPressed || EventSystem.current.IsPointerOverGameObject(0))
        {
            OnClick.Invoke();
        }
    }
}
