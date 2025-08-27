using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectController : MonoBehaviour
{
    public float speed;
    int howToMove;
    private Vector3 screenCenter;
    float pos;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image=this.GetComponent<Image>();
        howToMove = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        screenCenter=Camera.main.ScreenToViewportPoint(new Vector3(Screen.width/2,Screen.height/2,Camera.main.nearClipPlane));
        Debug.Log(screenCenter);
        if (howToMove==0) transform.position=Vector3.Lerp(transform.position, screenCenter, speed * Time.deltaTime);
        if (howToMove==1) transform.position=Vector3.Slerp(transform.position, screenCenter, speed * Time.deltaTime);
        pos=Vector3.Distance(transform.position, screenCenter);//íÜâõÇ…óàÇΩÇ©ämÇ©ÇﬂÇÈÇΩÇﬂÇÃïœêî
        Debug.Log(pos);
    }
    public void OnClick()
    {
        Destroy(this.gameObject);
    }
}
