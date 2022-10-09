using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Summon : MonoBehaviour
{
    public GameObject[] planePrefabs1;
    private float spawnRangeX = 10;
    public float spawnPosZ = 30;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, planePrefabs1.Length);
            Instantiate(planePrefabs1[animalIndex], spawnPos, planePrefabs1[animalIndex].transform.rotation);
        }
    }
}
