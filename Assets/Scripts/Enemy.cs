using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float count;
    private Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 3 + targetpos.x, targetpos.y);

        if (Input.GetKey(KeyCode.Z))
        {
            count -= 30;
            if (count <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Bullet"|| collision.gameObject.tag == "Laser")
        {
            count -= 1;

            if (count <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
