using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("startButton")) && Time.timeScale == 0)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        UI.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }
    public void EndMission()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
