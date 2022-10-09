using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Button button;
    public int scene = 1;
	
    // Start is called before the first frame update
    void Start()
    {
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
		
		SceneManager.LoadScene(scene);
    }
}
