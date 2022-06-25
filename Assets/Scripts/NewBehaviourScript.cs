using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform target;
    private Transform Top;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.07f);
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
       {
           Destroy(gameObject);
        }
    }
}
