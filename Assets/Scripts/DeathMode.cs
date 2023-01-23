using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMode : MonoBehaviour
{

    private Button button;
    public GameObject text;
    public LoadScene loadScene;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        int inDeathMode = PlayerPrefs.GetInt("DeathMode", 0);
        if (inDeathMode == 0)
        {
            button.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            text.SetActive(false);
        }
        else
        {
            button.GetComponent<Image>().color = Color.red;
            text.SetActive(true);
        }
    }
    void SetDifficulty()
    {
        int inDeathMode = PlayerPrefs.GetInt("DeathMode", 0);
        if (inDeathMode == 0 && loadScene.isUnlocked)
        {
            PlayerPrefs.SetInt("DeathMode", 1);
            button.GetComponent<Image>().color = Color.red;
            text.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("DeathMode", 0);
            button.GetComponent<Image>().color = new Color(0,0,0,0);
            text.SetActive(false);
        }
    }

}
