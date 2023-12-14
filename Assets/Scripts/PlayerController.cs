using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public float horizontalInput;
    [HideInInspector] public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float zRange = 10;
    public float negZRange = 10;
    public GameObject projectilePrefab;
    public GameObject FireButtonMobile;
    private Button mobileFireButton;
    private bool canFire = true;
    private float FireDelay = 0.25f;

    private float maxPickingDistance = 10000;// increase if needed, depending on your scene size

    private Vector3 startPos;

    private Transform pickedObject = null;

    void Start()
    {
    #if (UNITY_ANDROID || UNITY_WP_8_1 || UNITY_IOS) && !UNITY_EDITOR
        FireButtonMobile.SetActive(true);
        //pickedObject = gameObject.transform;
    #endif
        mobileFireButton = FireButtonMobile.GetComponent<Button>();
        Debug.Log(mobileFireButton);
        mobileFireButton.onClick.AddListener(MobileFire);
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_ANDROID || UNITY_WP_8_1 || UNITY_IOS) && !UNITY_EDITOR
            Debug.Log("Phone");
            for (int i = 0; i < Input.touchCount; ++i)
            {
                foreach (Touch touch in Input.touches)
                {
                    //Create horizontal plane
                    Plane horPlane = new Plane(Vector3.up, Vector3.zero);

                    //Gets the ray at position where the screen is touched
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (touch.phase == TouchPhase.Began)
                    {
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit, maxPickingDistance) && hit.transform.gameObject.tag == "Player")
                        {
                            pickedObject = hit.transform;
                            startPos = touch.position;
                        }
                        else
                        {
                            //pickedObject = null;
                        }
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        if (pickedObject != null)
                        {
                            float distance1 = 0f;
                            if (horPlane.Raycast(ray, out distance1))
                            {
                                pickedObject.transform.position = ray.GetPoint(distance1);
                                if (transform.position.x < -xRange)
                                {
                                    transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
                                }
                                else if (transform.position.x > xRange)
                                {
                                    transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
                                }
                                if (transform.position.z < -negZRange)
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y, -negZRange);
                                }
                                else if (transform.position.z > zRange)
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
                                }
                            }
                        }
                    }
                    /*else if (touch.phase == TouchPhase.Ended)
                    {
                        pickedObject = null;
                    }*/
                }
            }

                
#else
        Debug.Log("Computer");
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -negZRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -negZRange);
            }
            else if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire2"))
            {
                if (canFire)
                {
                    // Launch a projectile from the file
                    Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                    canFire = false;
                    Invoke("Reload", FireDelay);
                }
            }   
#endif

    }
    /*Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                //if (Input.GetTouch(i).position.x< (((float)Screen.width) / 2.0f) && Input.GetTouch(i).position.y < 200){
                    //transform.Translate(Vector3.right * -1 * Time.deltaTime * speed);
                //}
                //else if (Input.GetTouch(i).position.y < 200){
                    //transform.Translate(Vector3.right * 1 * Time.deltaTime * speed);
                //}
                if (touchPos.x < transform.position.x){
                    transform.Translate(Vector3.right * -1 * Time.deltaTime * speed);
                }
                else {
                    transform.Translate(Vector3.right * 1 * Time.deltaTime * speed);
                }
                if (touchPos.z < transform.position.z){
                    transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);
                }
                else {
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime * speed);
                }
            }
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -negZRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -negZRange);
            }
            else if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }*/


    public void MobileFire()
    {
        if (canFire)
        {
            Debug.Log(1);
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            canFire = false;
            Invoke("Reload", FireDelay);
        }
    }

    public void Reload()
    {
        canFire = true;
    }

}
