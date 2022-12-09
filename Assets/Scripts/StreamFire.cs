using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StreamFire : MonoBehaviour
{
    public GameObject projectilePrefab;
	public GameObject projectilePrefabAlt;
    public float Delay;
	public int fireTimes = 1;
	public bool sidesVSRandom = true;
    // Start is called before the first frame update
	
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
		if (sidesVSRandom)
		{
			if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 12)
			{

				yield return new WaitForSeconds(Delay);
				var bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, 180, 0);
				var bullet2 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet2.transform.Rotate(0, 150, 0);
				var bullet3 = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet3.transform.Rotate(0, 210, 0);

				for (int i = 0; i < fireTimes - 1; i++)
				{
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

					for (int i = 0; i < fireTimes - 1; i++)
					{
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
			else
			{
				yield return new WaitForSeconds(Delay);
				var bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
				bullet.transform.Rotate(0, 180, 0);
				var bullet2 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
				bullet2.transform.Rotate(0, 150, 0);
				var bullet3 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
				bullet3.transform.Rotate(0, 210, 0);

				for (int i = 0; i < fireTimes - 1; i++)
				{
					yield return new WaitForSeconds(0.1f);
					bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet.transform.Rotate(0, 180, 0);
					bullet2 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet2.transform.Rotate(0, 150, 0);
					bullet3 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet3.transform.Rotate(0, 210, 0);
				}


				while (true)
				{
					yield return new WaitForSeconds(Delay);
					bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet.transform.Rotate(0, 180, 0);
					bullet2 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet2.transform.Rotate(0, 150, 0);
					bullet3 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
					bullet3.transform.Rotate(0, 210, 0);

					for (int i = 0; i < fireTimes - 1; i++)
					{
						yield return new WaitForSeconds(0.1f);
						bullet = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
						bullet.transform.Rotate(0, 180, 0);
						bullet2 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
						bullet2.transform.Rotate(0, 150, 0);
						bullet3 = Instantiate(projectilePrefabAlt, transform.position, projectilePrefabAlt.transform.rotation);
						bullet3.transform.Rotate(0, 210, 0);
					}

				}
			}
			
		}
        else
        {
			int angle = Random.Range(135, 215);
			yield return new WaitForSeconds(Delay);
			var bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
			bullet.transform.Rotate(0, angle, 0);

			for (int i = 0; i < fireTimes - 1; i++)
			{
				yield return new WaitForSeconds(0.1f);
				bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, angle, 0);
			}

			while (true)
			{
				angle = Random.Range(135, 215);
				yield return new WaitForSeconds(Delay);
				bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
				bullet.transform.Rotate(0, angle, 0);

				for (int i = 0; i < fireTimes - 1; i++)
				{
					yield return new WaitForSeconds(0.1f);
					bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
					bullet.transform.Rotate(0, angle, 0);
				}

			}
		}
    }
    
}
