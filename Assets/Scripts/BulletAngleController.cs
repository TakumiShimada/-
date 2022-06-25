using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAngleController : MonoBehaviour
{
    // ���x
    public float Speedx;
    public float Speedy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������ɒe���ړ�
        transform.position += new Vector3(Speedx, Speedy, 0) * Time.deltaTime;
    }

    // �J�����ɕ\������Ȃ��Ȃ������A��������
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if (transform.position.x > 3||transform.position.x<-3)
            {
                Speedx = -Speedx;
                if (Speedx < 0)
                {
                    Speedx -= 2;
                }
                else
                {
                    Speedx += 2;
                }
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
