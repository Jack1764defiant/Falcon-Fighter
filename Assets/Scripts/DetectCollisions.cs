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

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindWithTag("scoreText").GetComponent<TextMeshProUGUI>();
        Debug.Log(scoreText);
    }

    // Update is called once per frame
    void Update()
    {
        
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
					Destroy(gameObject);
				}
				else{
					Instantiate(smallExplode, other.transform.position, other.transform.rotation);
					Destroy(other.gameObject);
				}
				
            }
			else{
				if (explode != null){
					Instantiate(explode, transform.position, transform.rotation);
				}
				Destroy(other.gameObject);
				if (enemyTag == "EnemyBullet"){
					GetComponent<MeshRenderer>().enabled = false;
					for( int i = 0; i < transform.childCount; ++i )
					{
						transform.GetChild(i).gameObject.SetActiveRecursively(false);
					}
					explode = null;
					GetComponent<PlayerController>().enabled = false;
					Destroy(gameObject, 2);
				}
			}
        }
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
