using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuikaMover : MonoBehaviour
{
    public enum SuikaType
    {
        suika,
        human,
        ball,
    }

    public float speed = 5f; // 移動速度（単位：units/sec）
    private float screenRightEdge;
    private float screenLeftEdge;
    private SceneManeger sceneManeger;
    public void setup(SceneManeger Maneger)
    {
        sceneManeger = Maneger;
    }

    [SerializeField] private Vector3 StartPosition;
    [SerializeField] private SuikaType suika;

    void Start()
    {
        // カメラの画面端を取得（ワールド座標）
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenRightEdge = screenBounds.x + 0f; // 画面右 + 少し余裕
        screenLeftEdge = -screenBounds.x - 0f; // 画面左 - 少し余裕

        // スイカを画面左外に初期配置
        transform.position = StartPosition;
    }

    void Update()
    {
        // 一定速度で右方向に移動
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //// 画面右外に到達したらオブジェクトを削除
        //if (transform.position.x > screenRightEdge)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // スイカが移動制限エリアに衝突した場合
        if (collision.gameObject.CompareTag("WatermelonMovelimit"))
        {
            Destroy(gameObject);
        }
        // スイカがバットに衝突した場合
        if (collision.gameObject.CompareTag("Bat"))
        {
            if (suika==SuikaType.suika)
            {
                sceneManeger.addmelonDestroyCount();
            }
            if(suika==SuikaType.human)
            {
                sceneManeger.addhumanDestroyCount();
            }
            if(suika==SuikaType.ball)
            {
                sceneManeger.addballDestroyCount();
            }
            Destroy(gameObject);
        }
    }
}


