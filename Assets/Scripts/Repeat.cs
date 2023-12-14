using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{
    public float lowerBound = -10;
    public Vector3 returnPos;
    // Start is called before the first frame update
    void Awake()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if (transform.position.z < lowerBound)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, returnPos.z);
        }
    }
}
