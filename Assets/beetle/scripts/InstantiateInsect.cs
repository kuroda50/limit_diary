using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateInsect : MonoBehaviour
{
   Å@[SerializeField] GameObject resultText;

    public Canvas canvas;
    public GameObject[] insects;
    public int catchCount;
    float constant = 3;
    float angle;
    float rad;
    float rx;
    float ry;
    float radius;
    Text text;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        text=resultText.GetComponent<Text>();
        timer = GameObject.Find("TimerBase").GetComponent<Timer>();
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
        text.text = $"íéÇ{ catchCount.ToString()}Ç–Ç´ïﬂÇ‹Ç¶ÇΩÅI";
    }
   
    IEnumerator Insect()//â~èÛÇ…ê∂ê¨
    {
        yield return new WaitForSeconds(1);
        while (timer.IsGameOver())
        {
            GameObject Object = Instantiate(insects[Random.Range(0, insects.Length)], new Vector3(rx, ry, 0), Quaternion.identity);
            Object.transform.SetParent(canvas.transform, false);
            yield return new WaitForSeconds(constant);
        }
    }
}
