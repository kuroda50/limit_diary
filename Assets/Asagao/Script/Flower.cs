using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private float water = 0;
    private bool isClier = false;

    [SerializeField] Canvas successResultCanvas;
    [SerializeField] Canvas failureResultCanvas;
    [SerializeField] private GameObject asagao;
    [SerializeField] Buket buket;
    [SerializeField] Buket hit_buket;
    [SerializeField] float setWater;
    [SerializeField] float ClierLineMin;
    [SerializeField] float ClierLineMax;

    public float GetWater()
    {
        return water;
    }

    // Start is called before the first frame update
    void Start()
    {
        asagao.SetActive(false);
        water = setWater;
        isClier = false;
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用　リセット
        //if (Input.GetKey(KeyCode.R))
        //{
        //    water = setWater;
        //    isClier = false;
        //    buket.ResetInput();
        //    hit_buket.ResetInput();
        //}

        // クリア判定 クリアライン内に水分量ゲージが収まっている時　クリアラインは手入力　アホですみません
        // 晴れ：普通、　曇り：簡単、　雨：難しい、　ぐらいで設定してます
        if (buket.GetInput() && !isClier && (ClierLineMin <= water/100 && water/100 <= ClierLineMax))
        {
            isClier = true;
        }

        if (isClier)
        {
            // クリア処理　成長した朝顔を重ねて表示
            asagao.SetActive(true);
            // いい感じのエフェクトとか音とか　任せます　ごめんなさい

            successResultCanvas.enabled = true;
        }
        else if(buket.GetInput())
        {
            // 失敗処理
            // いい感じのエフェクトとか音とか　任せます　ごめんなさい
            failureResultCanvas.enabled = true;
        }

    }

    // 当たり判定で水分量を増やす　UI関係なし　見えないオブジェクトとしてます
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            water += 1 + (1*buket.GetPower());
        }
    }
}
