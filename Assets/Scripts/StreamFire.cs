using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamFire : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float Delay;
	public int fireTimes = 1;
    // Start is called before the first frame update
	
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
         yield return new WaitForSeconds(Delay);
            var bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            bullet.transform.Rotate(0, 180, 0);
			var bullet2 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet2.transform.Rotate(0, 150, 0);
			var bullet3 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet3.transform.Rotate(0, 210, 0);
			
			for (int i = 0; i < fireTimes -1; i ++){
				yield return new WaitForSeconds(0.1f);
				bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, 180, 0);
				bullet2 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet2.transform.Rotate(0, 150, 0);
				bullet3 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet3.transform.Rotate(0, 210, 0);
			}
			
		
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            bullet.transform.Rotate(0, 180, 0);
			bullet2 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet2.transform.Rotate(0, 150, 0);
			bullet3 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet3.transform.Rotate(0, 210, 0);
			
			for (int i = 0; i < fireTimes -1; i ++){
				yield return new WaitForSeconds(0.1f);
				bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, 180, 0);
				bullet2 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet2.transform.Rotate(0, 150, 0);
				bullet3 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet3.transform.Rotate(0, 210, 0);
			}
			
        }
    }
    
}
