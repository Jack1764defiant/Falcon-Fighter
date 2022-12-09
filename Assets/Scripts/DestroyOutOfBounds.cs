using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30;
    public float lowerBound = -10;
	public float topBound2 = 21;
    public float lowerBound2 = -21;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
       else if (transform.position.z < lowerBound)
        {
            //Debug.Log("Game Over!");
            Destroy(gameObject);
        }
		if (transform.position.x > topBound2)
        {
            Destroy(gameObject);
        }
       else if (transform.position.x < lowerBound2)
        {
            //Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
