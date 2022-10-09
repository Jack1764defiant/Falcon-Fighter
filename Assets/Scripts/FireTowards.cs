using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowards : MonoBehaviour
{
    public GameObject projectilePrefab;
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
    
}
