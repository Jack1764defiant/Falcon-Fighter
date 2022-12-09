using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : MonoBehaviour
{
    public GameObject[] planePrefabs1;
	public GameObject[] planePrefabs2;
	public GameObject[] planePrefabs3;
	public GameObject[] bossPrefabs1;
	public GameObject[] bossPrefabs2;
	public GameObject[] bossPrefabs3;
    public float spawnRangeX = 10;
    public float spawnPosZ = 30;
    private float startDelay = 2;
    public float spawnInterval = 1.5f;
    private float waveCount = 0;
	public int wavesBeforeBoss = 25;
	public float waveTimeReduce = 0.5f;
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
		while (true)
		{
			while (waveCount < wavesBeforeBoss)
			{
				yield return new WaitForSeconds(spawnInterval);
				waveCount++;
				Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
				int animalIndex = Random.Range(0, planePrefabs1.Length);
				Instantiate(planePrefabs1[animalIndex], spawnPos, planePrefabs1[animalIndex].transform.rotation);
			}
			yield return new WaitForSeconds(3);
			int bossIndex1 = Random.Range(0, bossPrefabs1.Length);
			var iboss1 = Instantiate(bossPrefabs1[bossIndex1], new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), bossPrefabs1[bossIndex1].transform.rotation);

			while (iboss1 != null)
			{
				yield return null;
			}
			player.GetComponent<DetectCollisions>().health += 1;
			PlayerPrefs.SetInt("Lives", player.GetComponent<DetectCollisions>().health);
			waveCount = 0;



			while (waveCount < wavesBeforeBoss)
			{
				yield return new WaitForSeconds(spawnInterval);
				waveCount++;
				Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
				int animalIndex = Random.Range(0, planePrefabs2.Length);
				Instantiate(planePrefabs2[animalIndex], spawnPos, planePrefabs2[animalIndex].transform.rotation);
			}
			yield return new WaitForSeconds(3);
			int bossIndex2 = Random.Range(0, bossPrefabs2.Length);
			var iboss2 = Instantiate(bossPrefabs2[bossIndex2], new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), bossPrefabs2[bossIndex2].transform.rotation);

			while (iboss2 != null)
			{
				yield return null;
			}
			player.GetComponent<DetectCollisions>().health += 1;
			PlayerPrefs.SetInt("Lives", player.GetComponent<DetectCollisions>().health);
			waveCount = 0;



			while (waveCount < wavesBeforeBoss)
			{
				yield return new WaitForSeconds(spawnInterval);
				waveCount++;
				Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
				int animalIndex = Random.Range(0, planePrefabs3.Length);
				Instantiate(planePrefabs3[animalIndex], spawnPos, planePrefabs3[animalIndex].transform.rotation);
			}
			yield return new WaitForSeconds(3);
			int bossIndex3 = Random.Range(0, bossPrefabs3.Length);
			var iboss3 = Instantiate(bossPrefabs3[bossIndex3], new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), bossPrefabs3[bossIndex3].transform.rotation);

			while (iboss3 != null)
			{
				yield return null;
			}
			player.GetComponent<DetectCollisions>().health += 1;
			PlayerPrefs.SetInt("Lives", player.GetComponent<DetectCollisions>().health);
			waveCount = 0;
		}
	}

}
