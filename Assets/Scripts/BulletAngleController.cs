using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAngleController : MonoBehaviour
{
    // 速度
    public float Speedx;
    public float Speedy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 下から上に弾を移動
        transform.position += new Vector3(Speedx, Speedy, 0) * Time.deltaTime;
    }

    // カメラに表示されなくなった時、消去する
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
