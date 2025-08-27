using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateInsect : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] insects;
    public int catchCount;
    float constant = 3;
    float angle;
    float rad;
    float rx;
    float ry;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = Screen.width;
        StartCoroutine(Insect());
    }

    // Update is called once per frame
    void Update()
    {
        angle = Random.Range(0, 360);
        rad = angle * Mathf.Deg2Rad;
        rx= Mathf.Cos(rad) * radius;
        ry= Mathf.Sin(rad) * radius;
    }
   
    IEnumerator Insect()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            GameObject Object = Instantiate(insects[Random.Range(0, insects.Length)], new Vector3(rx, ry, 0), Quaternion.identity);
            Object.transform.SetParent(canvas.transform, false);
            yield return new WaitForSeconds(constant);
        }
    }
}
