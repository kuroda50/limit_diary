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

    public float speed = 5f; // �ړ����x�i�P�ʁFunits/sec�j
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
        // �J�����̉�ʒ[���擾�i���[���h���W�j
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenRightEdge = screenBounds.x + 0f; // ��ʉE + �����]�T
        screenLeftEdge = -screenBounds.x - 0f; // ��ʍ� - �����]�T

        // �X�C�J����ʍ��O�ɏ����z�u
        transform.position = StartPosition;
    }

    void Update()
    {
        // ��葬�x�ŉE�����Ɉړ�
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //// ��ʉE�O�ɓ��B������I�u�W�F�N�g���폜
        //if (transform.position.x > screenRightEdge)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �X�C�J���ړ������G���A�ɏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("WatermelonMovelimit"))
        {
            Destroy(gameObject);
        }
        // �X�C�J���o�b�g�ɏՓ˂����ꍇ
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


