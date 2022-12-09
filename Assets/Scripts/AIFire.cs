using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIFire : MonoBehaviour
{
    public GameObject projectilePrefab;
	public GameObject projectilePrefabAlt;
    public float Delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
		if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 12)
		{
			yield return new WaitForSeconds(0.25f);
			var bullet1 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet1.transform.Rotate(0, Random.Range(135, 215), 0);
			while (true)
			{
				yield return new WaitForSeconds(Delay);
				var bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, Random.Range(135, 215), 0);
			}
		}
		else{
			yield return new WaitForSeconds(0.25f);
			var bullet1 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
			bullet1.transform.Rotate(0, Random.Range(135, 215), 0);
			while (true)
			{
				yield return new WaitForSeconds(Delay);
				var bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
				bullet.transform.Rotate(0, Random.Range(135, 215), 0);
			}
			
		}
    }
    
}
