using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // ���x
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // �������ɒe���ړ�
        transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
    }
    // �J�����ɕ\������Ȃ��Ȃ������A��������
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