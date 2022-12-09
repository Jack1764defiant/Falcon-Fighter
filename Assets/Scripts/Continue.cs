using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    private Button button;
    private int scene = 1;
	
    // Start is called before the first frame update
    void Start()
    {
		scene = PlayerPrefs.GetInt( "curScene", 0);
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
	void Update(){
		if (Input.GetButtonDown("Fire2"))
        {
            // Launch a projectile from the file
            //SceneManager.LoadScene(scene);
        }
		
	}
    void SetDifficulty()
    {
		
		SceneManager.LoadScene(scene+1);
    }
}
