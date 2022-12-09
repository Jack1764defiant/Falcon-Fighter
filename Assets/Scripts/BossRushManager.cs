using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRushManager : MonoBehaviour
{
    public GameObject[] Bosses;
    public float spawnRangeX = 10;
    public float spawnPosZ = 30;
    private float startDelay = 2;
	private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
        StartCoroutine(Spawn());
		player = GameObject.FindWithTag("Player");
		int curScene = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt( "curScene", curScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startDelay);
		for (int i = 0; i < Bosses.Length; i++)
		{
			yield return new WaitForSeconds(3);
			var iboss = Instantiate(Bosses[i], new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), Bosses[i].transform.rotation);

			while (iboss != null)
			{
				yield return null;
			}
            if (player.GetComponent<DetectCollisions>().health < 3 && i % 3 == 0)
            {
                player.GetComponent<DetectCollisions>().health += 1;
                PlayerPrefs.SetInt("Lives", player.GetComponent<DetectCollisions>().health);
            }
		}
		yield return new WaitForSeconds(1.5f);
        LevelController.instance.Save(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(1);
    }
}
