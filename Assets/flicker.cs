using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public Camera toUpdate;
    public static flicker instance;
    public GameObject toFlicker;
    void LateUpdate()
    {
        toUpdate.Render();
    }
    

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    public void TriggerUpdate()
    {
        StartCoroutine(Flick());
    }

    IEnumerator Flick()
    {
        yield return null;
        toFlicker.SetActive(!toFlicker.activeSelf);
        yield return null;
        toFlicker.SetActive(!toFlicker.activeSelf);
    }
}
