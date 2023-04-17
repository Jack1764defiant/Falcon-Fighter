using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Continue();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Continue();
        }
    }
    public void Continue()
    {
        PlayerPrefs.SetInt("HasLoadedBefore", 1);
        SceneManager.LoadScene(0);
    }

}
