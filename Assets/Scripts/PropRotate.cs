using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRotate : MonoBehaviour
{
    public string axis = "y";
    public float speed = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (axis.Trim().ToLower() == "x")
        {
            transform.Rotate(speed, 0, 0);
        }
        else if (axis.Trim().ToLower() == "y")
        {
            transform.Rotate(0, speed, 0);
        }
        else if (axis.Trim().ToLower() == "z")
        {
            transform.Rotate(0, 0, speed);
        }
        else
        {
            Debug.Log("Not an option");
        }

    }
}
