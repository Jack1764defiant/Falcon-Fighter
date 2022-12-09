using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
	public float pulseTime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pulse());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
	IEnumerator pulse(){
		while (true){
			yield return new WaitForSeconds(pulseTime);
			gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
			gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red*3);
			yield return new WaitForSeconds(pulseTime);
			gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
			gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
			
		}
		
	}
}
