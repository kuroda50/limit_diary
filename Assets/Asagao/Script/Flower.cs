using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private float water = 0;
    private bool isClier = false;

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
        // �f�o�b�O�p�@���Z�b�g
        //if (Input.GetKey(KeyCode.R))
        //{
        //    water = setWater;
        //    isClier = false;
        //    buket.ResetInput();
        //    hit_buket.ResetInput();
        //}

        // �N���A���� �N���A���C�����ɐ����ʃQ�[�W�����܂��Ă��鎞�@�N���A���C���͎���́@�A�z�ł��݂܂���
        // ����F���ʁA�@�܂�F�ȒP�A�@�J�F����A�@���炢�Őݒ肵�Ă܂�
        if (buket.GetInput() && !isClier && (ClierLineMin <= water/100 && water/100 <= ClierLineMax))
        {
            isClier = true;
        }

        if (isClier)
        {
            // �N���A�����@��������������d�˂ĕ\��
            asagao.SetActive(true);
            // ���������̃G�t�F�N�g�Ƃ����Ƃ��@�C���܂��@���߂�Ȃ���


        }
        else if(buket.GetInput())
        {
            // ���s����
            // ���������̃G�t�F�N�g�Ƃ����Ƃ��@�C���܂��@���߂�Ȃ���


        }

    }

    // �����蔻��Ő����ʂ𑝂₷�@UI�֌W�Ȃ��@�����Ȃ��I�u�W�F�N�g�Ƃ��Ă܂�
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            water += 1 + (1*buket.GetPower());
        }
    }
}
