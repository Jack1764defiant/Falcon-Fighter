using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Home();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Home();
        }
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
