using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] planePrefabs1;
	public GameObject[] planePrefabs2;
	public GameObject[] planePrefabs3;
    public GameObject boss1;
	public GameObject boss2;
	public GameObject boss3;
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
#if (UNITY_ANDROID || UNITY_WP_8_1 || UNITY_IOS) && !UNITY_EDITOR
            wavesBeforeBoss = Mathf.FloorToInt(wavesBeforeBoss*1.5f);
            spawnInterval = spawnInterval*2f/3f;
#endif
	}

	// Update is called once per frame
	void Update()
    {

    }
    IEnumerator Spawn()
    {
        while (waveCount < wavesBeforeBoss)
        {
			yield return new WaitForSeconds(spawnInterval);
			waveCount++;
            //if (spawnInterval > 1)
                //spawnInterval -= 0.1f;
            //Debug.Log("spawn"+ spawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, planePrefabs1.Length);
            Instantiate(planePrefabs1[animalIndex], spawnPos, planePrefabs1[animalIndex].transform.rotation);
        }
        yield return new WaitForSeconds(3);
        var iboss1 = Instantiate(boss1, new Vector3(Random.Range(-spawnRangeX/2, spawnRangeX/2), 0, spawnPosZ), boss1.transform.rotation);
		
		while (iboss1 != null){
			yield return null;
		}
		player.GetComponent<DetectCollisions>().health += 1;
		PlayerPrefs.SetInt( "Lives", player.GetComponent<DetectCollisions>().health);
		spawnInterval -= waveTimeReduce;
		while (waveCount < wavesBeforeBoss*2)
		{
			yield return new WaitForSeconds(spawnInterval);
			waveCount++;
			//if (spawnInterval > 1)
				//spawnInterval -= 0.1f;
			//Debug.Log("spawn"+ spawnInterval);
			Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
			int animalIndex = Random.Range(0, planePrefabs2.Length);
			Instantiate(planePrefabs2[animalIndex], spawnPos, planePrefabs2[animalIndex].transform.rotation);
		}
		yield return new WaitForSeconds(3);
		var iboss2 = Instantiate(boss2, new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), boss2.transform.rotation);
		
		while (iboss2 != null){
			yield return null; 
		}
		player.GetComponent<DetectCollisions>().health += 1;
		PlayerPrefs.SetInt( "Lives", player.GetComponent<DetectCollisions>().health);
		spawnInterval -= waveTimeReduce;
		while (waveCount < wavesBeforeBoss*3)
		{
			yield return new WaitForSeconds(spawnInterval);
			waveCount++;
			//if (spawnInterval > 1)
				//spawnInterval -= 0.1f;
			//Debug.Log("spawn"+ spawnInterval);
			Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
			int animalIndex = Random.Range(0, planePrefabs3.Length);
			Instantiate(planePrefabs3[animalIndex], spawnPos, planePrefabs3[animalIndex].transform.rotation);
		}
		yield return new WaitForSeconds(3);
		var iboss3 = Instantiate(boss3, new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0, spawnPosZ), boss3.transform.rotation);
		while (iboss3 != null){
			yield return null; 
		}
		player.GetComponent<DetectCollisions>().health += 1;
		PlayerPrefs.SetInt( "Lives", player.GetComponent<DetectCollisions>().health);
		yield return new WaitForSeconds(1.5f);
		LevelController.instance.Save(SceneManager.GetActiveScene().buildIndex-1);
		SceneManager.LoadScene(1);
    }
}
