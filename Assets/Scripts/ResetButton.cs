using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    private Button button;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
    void SetDifficulty()
    {
        LevelController.instance.Reset();
        SceneManager.LoadScene(0);
    }



}
