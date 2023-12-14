using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrike : MonoBehaviour
{
    public GameObject explosion;
    public void Trigger(float time)
    {
        StartCoroutine(Activate(time));
    }
    IEnumerator Activate(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(explosion, transform.position, transform.rotation);
        GetComponent<CapsuleCollider>().enabled = true;
        yield return null;
        yield return null;
        Destroy(gameObject);
    }
}
