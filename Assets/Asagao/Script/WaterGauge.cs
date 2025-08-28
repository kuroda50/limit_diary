using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGauge : MonoBehaviour
{
    // MAX������
    private float Max;
    private float water = 0;

    // �����ʂɂ��p�[�Z���g�� ����Ȃ�����
    private float percent;
    
    [SerializeField] GameObject Asagao;
    [SerializeField] Flower flower;

    public float GetPercent()
    {
        return percent;
    }

    // Start is called before the first frame update
    void Start()
    {
        Max = 100.0f;
        percent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �����ʂ��擾���ăQ�[�W�ɔ��f
        water = flower.GetWater();
        percent = (water / Max);
        if(percent > 1)
        {
            percent = 1;
        }
        this.GetComponent<Image>().fillAmount = percent;
    }
}
