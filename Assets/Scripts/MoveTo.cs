using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
	public float bottom = 25;
	public float speed = 5;
	public float rightSpeed = 3;
	public float sideBound = 7;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > bottom){
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if(transform.position.x > sideBound){
			rightSpeed*=-1;
			transform.Translate(Vector3.right * Time.deltaTime * rightSpeed);
		}
		else if(transform.position.x < -sideBound){
			rightSpeed*=-1;
			transform.Translate(Vector3.right * Time.deltaTime * rightSpeed);
		}
		transform.Translate(Vector3.right * Time.deltaTime * rightSpeed);

    }
}
