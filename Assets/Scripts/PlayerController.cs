using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �v���C���[�̈ړ����x
    public float Speed;
    // �e�̃v���n�u
    public GameObject BulletPrefab;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject laserPrefab;

    // ���b�Ԋu�Ō���
    private float interval=0.3f;
    private float interval1 = 2.0f;

    // ���ԃJ�E���g�p�̃^�C�}�[
    private float timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����L�[�œ��͂��ꂽ�����̒l���擾
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // ���݈ʒu��x,y �̒l�����Z����
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * Speed;

        //�ړ�����
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -3.25f, 3.25f);
        currentPos.y = Mathf.Clamp(currentPos.y, -4.5f ,4.5f);
        transform.position = currentPos;

        //�X�y�[�X�L�[�������ꂽ��e�𔭎�
        if (Input.GetKey(KeyCode.Space) && timer <= 0.0 )
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Instantiate(BulletPrefab1, transform.position, Quaternion.identity);
            Instantiate(BulletPrefab2, transform.position, Quaternion.identity);

            // �Ԋu���Z�b�g
            timer = interval;
        }
        if (Input.GetKeyDown(KeyCode.X)&&timer <= 0.0 )
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);

            timer = interval1;
        }

            // �^�C�}�[�̒l�����炷
            if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
    }
}
