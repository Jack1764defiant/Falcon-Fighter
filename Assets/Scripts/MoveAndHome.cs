using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndHome : MonoBehaviour
{
    public float speed = 10.0f;
    public float exploSize = 1.25f;
    public float Damage = 1;
    public ParticleSystem explode;
    private Transform target;
    public float turnSpeed = 0.1f;
    private float focusDistance = 5;
    private bool isLookingAtObject = true;
    public ParticleSystem lightBlue;
    public ParticleSystem Blue;
    // Start is called before the first frame update
    void Start()
    {
        lockOn();
		Destroy(gameObject, 5f);
    }
    // Update is called once per frame
	
	
    void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0F);

            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

            if (Vector3.Distance(transform.position, target.position) < focusDistance)
            {
                isLookingAtObject = false;
            }

            if (isLookingAtObject)
            {
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
            else
            {
                lightBlue.gameObject.SetActive(true);
                Blue.gameObject.SetActive(false);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            lightBlue.gameObject.SetActive(true);
            Blue.gameObject.SetActive(false);
        }
    }
    void ExplosionDamage(float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
			if (hitCollider.tag == "Player")
			{
				hitCollider.gameObject.SendMessage("AddDamage", Damage, SendMessageOptions.DontRequireReceiver);
			}
        }
    }
    /*void OnTriggerEnter(Collider hitCollider)
    {
		if (hitCollider.tag == "Player")
		{
			Instantiate(explode, transform.position, Quaternion.identity);
			ExplosionDamage(exploSize);
			Destroy(gameObject);
		}
    }*/
    void lockOn()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
