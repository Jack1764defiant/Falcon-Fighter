using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
	public List<GameObject> shields = new List<GameObject>();
	public GameObject newShield;
	
    void Start()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
		while (true){
			
			/*while (shields[0] == null){
				shields.RemoveAt(0);
			}*/
			if (shields.Count > 0){
				yield return new WaitForSeconds(3f);
				shields[0].gameObject.transform.parent = null;
				shields[0].transform.LookAt(-Vector3.forward);
				shields[0].GetComponent<MoveAndHome>().enabled = true;
				shields[0].GetComponent<DetectCollisions>().health = 10;
				shields.RemoveAt(0);
			}
			else{
				yield return new WaitForSeconds(1.5f);
				var createdShield = Instantiate(newShield, transform.position, transform.rotation);
				createdShield.gameObject.transform.parent = transform;
				for(int i = 0; i < createdShield.gameObject.transform.childCount; i++)
				{
				   shields.Add(createdShield.gameObject.transform.GetChild(i).gameObject);
				   
				}
				
			}
		
		}
		
		
    }
}
