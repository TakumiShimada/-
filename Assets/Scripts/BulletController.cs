using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 速度
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // 下から上に弾を移動
        transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
    }
    // カメラに表示されなくなった時、消去する
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy" )
        {
            Destroy(gameObject);
        }
    }
}