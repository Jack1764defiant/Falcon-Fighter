using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 40.0f;
    public float bottom = -5;
    public float top = 30;
    public List<GameObject> turrets = new List<GameObject>();
	public bool rotateTurrets = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            if (turrets[i] == null)
            {
                turrets.RemoveAt(i);
            }
        }
        if (turrets.Count <= 0)
        {
            GetComponent<DetectCollisions>().enabled = true;
			try{
				GetComponent<AIFire>().enabled = true;
			}
			catch{
			}
			try{
				GetComponent<FireTowards>().enabled = true;
			}
			catch{}
			try{
				GetComponent<StreamFire>().enabled = true;
			}
			catch{}
			GetComponent<DetectCollisions>().enemyTag = "PlayerBullet";
        }
        if (transform.position.z < bottom || transform.position.z > top)
        {
            transform.Rotate(0, 180, 0);
            if (transform.position.z < bottom){
				transform.position = new Vector3(5, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, bottom + 1);
			}
            else{
				transform.position = new Vector3(-5, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, top - 1);
			}
			if (rotateTurrets){
				foreach (GameObject turret in turrets)
				{
					turret.transform.Rotate(0, 180, 0);
				}
			}
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
