using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    public string enemyTag;
    public ParticleSystem explode;
    public TextMeshProUGUI scoreText;
    static int score = 0;
    public int reward = 10;
	public int health = 1; 
	public ParticleSystem smallExplode;
	public GameObject onDeath;
	public GameObject shield;
	public GameObject Heart1;
	public GameObject Heart2;
	public GameObject Heart3;
	int inDeathMode;

	// Start is called before the first frame update
	void Start()
    {
        scoreText = GameObject.FindWithTag("scoreText").GetComponent<TextMeshProUGUI>();
		
		if (enemyTag == "EnemyBullet"){
			health = PlayerPrefs.GetInt( "Lives", 1);
			if (health < 1){
					health = 1;
			}
		}
		inDeathMode = PlayerPrefs.GetInt("DeathMode", 0);
	}

    // Update is called once per frame
    void Update()
    {
		if (enemyTag == "EnemyBullet" && health > 3){
			health = 3;
		}
		try{
			if (health >= 3){
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(true);
			}
			else if (health == 2){
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(false);
			}
			else if (health == 1){
				Heart1.SetActive(true);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
			else{
				Heart1.SetActive(false);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
			if (health > 1 && inDeathMode == 1)
			{
				health = 1;
				PlayerPrefs.SetInt("Lives", health);
			}
			if (health >= 3)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(true);
			}
			else if (health == 2)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(true);
				Heart3.SetActive(false);
			}
			else if (health == 1)
			{
				Heart1.SetActive(true);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
			else
			{
				Heart1.SetActive(false);
				Heart2.SetActive(false);
				Heart3.SetActive(false);
			}
		}
		catch{}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag){
			health --;
            if (enemyTag == "PlayerBullet")
            {
				
				if (health <= 0){
					Destroy(other.gameObject);
					score += reward;
					//Debug.Log("Score");
					string zeros = "";
					for (int i = 0; i < (4-score.ToString().Length); i++)
					{
						zeros = zeros + "0";
					}
					try{
						scoreText.text = "SCORE: " + zeros + score;
					}
					catch{}
					Instantiate(explode, transform.position, transform.rotation);
					if (onDeath != null)
						Instantiate(onDeath, transform.position, transform.rotation, transform.parent);
					Destroy(gameObject);
				}
				else{
					Instantiate(smallExplode, other.transform.position, other.transform.rotation);
					Destroy(other.gameObject);
				}
				
            }
			else{
				if (health > 1 && inDeathMode == 1)
                {
					health = 1;
					PlayerPrefs.SetInt("Lives", health);
				}
				PlayerPrefs.SetInt( "Lives", health);
				if (health <= 0){
					if (explode != null){
						Instantiate(explode, transform.position, transform.rotation);
					}
                    if (onDeath != null)
                        Instantiate(onDeath, transform.position, transform.rotation, transform.parent);
                    Destroy(other.gameObject);
					if (enemyTag == "EnemyBullet"){
						GetComponent<MeshRenderer>().enabled = false;
						for( int i = 0; i < transform.childCount; ++i )
						{
							transform.GetChild(i).gameObject.SetActiveRecursively(false);
						}
						explode = null;
						onDeath = null;
						GetComponent<PlayerController>().enabled = false;
						Destroy(gameObject, 0.1f);
					}
				}
				else{
					Instantiate(smallExplode, other.transform.position, other.transform.rotation);
					Destroy(other.gameObject);
					StartCoroutine(invuln());
				}
				
			}
        }
    }
	IEnumerator invuln(){
		var enemyTag2 = enemyTag;
		enemyTag = "";
		Color tempColor = GetComponent<Renderer>().material.color;
        tempColor.a = 0.4f;
        GetComponent<Renderer>().material.color = tempColor;
		foreach (Transform child in transform)
		{
			try
			{
				child.gameObject.GetComponent<Renderer>().material.color = tempColor;
			}
			catch { }
        }
        //shield.SetActive(true);
        yield return new WaitForSeconds(2);
		enemyTag = enemyTag2;
        tempColor.a = 1f;
        GetComponent<Renderer>().material.color = tempColor;
        foreach (Transform child in transform)
        {
			try
			{
				child.gameObject.GetComponent<Renderer>().material.color = tempColor;
			}
			catch { }
        }
        //shield.SetActive(false);

    }
	void OnDestroy(){
		if (enemyTag == "EnemyBullet" && health <= 0){
			score = 0;
			scoreText.text = "SCORE: 0000";
			SceneManager.LoadScene(0);
			//Debug.Log("Dead");
		}
		
	}
}
