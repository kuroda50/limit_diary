using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buket : MonoBehaviour
{
    private int angle = 0;
    private float power = 0f;
    private Animator animator;
    private bool isonleyInput;

    [SerializeField] float setPower;

    public float GetPower()
    {
        return power;
    }

    public bool GetInput()
    {
        return isonleyInput;
    }

    public void ResetInput()
    {
        isonleyInput = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        power = 0.0f;
        animator = GetComponent<Animator>();
        isonleyInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 入力されたときの実行　チャレンジ回数は1回のみ
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!isonleyInput)
            {
                angle += 5;
                power += 0.01f * setPower;
                animator.SetBool("Watering", true);
                if (angle > 50)
                {
                    angle = 50;
                }
            }
        }
        else
        {
            angle -= 1;
            power = 0.01f;
            animator.SetBool("Watering", false);
            if (angle < 0)
            {
                angle = 0;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            isonleyInput = true;
        }
    }
}
