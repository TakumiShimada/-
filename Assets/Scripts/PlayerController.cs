using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤーの移動速度
    public float Speed;
    // 弾のプレハブ
    public GameObject BulletPrefab;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject laserPrefab;

    // 何秒間隔で撃つか
    private float interval=0.3f;
    private float interval1 = 2.0f;

    // 時間カウント用のタイマー
    private float timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 方向キーで入力された横軸の値を取得
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // 現在位置にx,y の値を加算する
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * Speed;

        //移動制限
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -3.25f, 3.25f);
        currentPos.y = Mathf.Clamp(currentPos.y, -4.5f ,4.5f);
        transform.position = currentPos;

        //スペースキーが押されたら弾を発射
        if (Input.GetKey(KeyCode.Space) && timer <= 0.0 )
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Instantiate(BulletPrefab1, transform.position, Quaternion.identity);
            Instantiate(BulletPrefab2, transform.position, Quaternion.identity);

            // 間隔をセット
            timer = interval;
        }
        if (Input.GetKeyDown(KeyCode.X)&&timer <= 0.0 )
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);

            timer = interval1;
        }

            // タイマーの値を減らす
            if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
    }
}
