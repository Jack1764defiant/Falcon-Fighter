using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireTowards : MonoBehaviour
{
    public GameObject projectilePrefab;
	 public GameObject projectilePrefabAlt;
    public float Delay;
	private GameObject player;
	public bool alwaysFire = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
		player = GameObject.FindWithTag("Player");
		Debug.Log(player);
    }
    IEnumerator Fire()
    {
		if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 12)
		{
			yield return new WaitForSeconds(0.25f);
			var bullet1 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet1.transform.LookAt(player.transform);
			while (transform.position.z > player.transform.position.z+3 || alwaysFire)
			{
				var bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.LookAt(player.transform);
				yield return new WaitForSeconds(Delay);
			}
		}
		else{
			yield return new WaitForSeconds(0.25f);
			var bullet1 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
			bullet1.transform.LookAt(player.transform);
			while (transform.position.z > player.transform.position.z+3 || alwaysFire)
			{
				var bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
				bullet.transform.LookAt(player.transform);
				yield return new WaitForSeconds(Delay);
			}
			
		}
    }
    
}
