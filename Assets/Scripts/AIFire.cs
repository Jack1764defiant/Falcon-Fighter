using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFire : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float Delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
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
    
}
