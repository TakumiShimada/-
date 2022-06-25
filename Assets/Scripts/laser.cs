using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform playerTrans; //�ǂ�������Ώۂ�Transform
    public float bulletSpeed;  �@ //�e�̑��x
    public float limitSpeed;      //�e�̐������x
    private Rigidbody2D rb;                         //�e��Rigidbody2D
    public Transform bulletTrans;                  //�e��Transform


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
        playerTrans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
            Vector3 vector3 = playerTrans.position - bulletTrans.position;  //�e����ǂ�������Ώۂւ̕������v�Z
            rb.AddForce(vector3.normalized * bulletSpeed);                  //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����

            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed); //X�����̑��x�𐧌�
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y�����̑��x�𐧌�
            rb.velocity = new Vector3(speedXTemp, speedYTemp);           //���ۂɐ��������l����
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
    // �J�����ɕ\������Ȃ��Ȃ������A��������
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
