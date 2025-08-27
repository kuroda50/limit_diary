using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        water = setWater;
        isClier = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            water = setWater;
            isClier = false;
            buket.ResetInput();
            hit_buket.ResetInput();
        }

        if (buket.GetInput() && !isClier && (ClierLineMin <= water/100 && water/100 <= ClierLineMax))
        {
            isClier = true;
        }

        if (isClier)
        {
            Debug.Log("Clear!");
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            water += 1 + (1*buket.GetPower());
        }
    }

    public float GetWater()
    {
        return water;
    }

}
