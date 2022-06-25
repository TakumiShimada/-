using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform playerTrans; //追いかける対象のTransform
    public float bulletSpeed;  　 //弾の速度
    public float limitSpeed;      //弾の制限速度
    private Rigidbody2D rb;                         //弾のRigidbody2D
    public Transform bulletTrans;                  //弾のTransform


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
        playerTrans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
            Vector3 vector3 = playerTrans.position - bulletTrans.position;  //弾から追いかける対象への方向を計算
            rb.AddForce(vector3.normalized * bulletSpeed);                  //方向の長さを1に正規化、任意の力をAddForceで加える

            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed); //X方向の速度を制限
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y方向の速度を制限
            rb.velocity = new Vector3(speedXTemp, speedYTemp);           //実際に制限した値を代入
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
    // カメラに表示されなくなった時、消去する
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
