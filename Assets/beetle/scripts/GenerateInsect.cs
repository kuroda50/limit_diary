using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateInsect : MonoBehaviour
{

    [SerializeField] GameObject result;
    [SerializeField] Sprite[] resultScreen;
    Image resultImage;
    public Canvas canvas;
    [SerializeField] GameObject[] insects;
    public int catchCount;
    float constant = 0.5f;
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
        resultImage = result.GetComponent<Image>();
        timer = GameObject.Find("TimerBase").GetComponent<Timer>();
        radius = Screen.width;
        StartCoroutine(Insect());
    }

    // Update is called once per frame
    void Update()
    {
        angle = Random.Range(0, 360);
        rad = angle * Mathf.Deg2Rad;
        rx = Mathf.Cos(rad) * radius;
        ry = Mathf.Sin(rad) * radius;
        if(catchCount>=10)resultImage.sprite = resultScreen[0];
        if (catchCount < 10) resultImage.sprite = resultScreen[1];
    }

    IEnumerator Insect()//‰~ó‚É¶¬
    {
        yield return new WaitForSeconds(1);
        while (!timer.IsGameOver())
        {
            Debug.LogWarning("¶¬");
            GameObject Object = Instantiate(insects[Random.Range(0, insects.Length)], new Vector3(rx, ry, 0), Quaternion.identity);
            Object.transform.SetParent(canvas.transform, false);
            yield return new WaitForSeconds(constant);
        }
    }
}
