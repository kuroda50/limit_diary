using UnityEngine;

public class InsectController : MonoBehaviour
{
    [SerializeField]float speed;//prefab‚©‚ç‚¢‚¶‚ê‚Ü‚·
    int howToMove;
    int howToEscape;
    private Vector2 screenCenter;
    float angle;
    float rad;
    float rx;
    float ry;
    float radius;
    float pos;
    bool isEated=false;
    InstantiateInsect instantiateInsect;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        instantiateInsect=GameObject.Find("comeInsect").GetComponent<InstantiateInsect>();
        timer = GameObject.Find("TimerBase").GetComponent<Timer>();
        howToMove = Random.Range(0, 3);
        howToEscape = Random.Range(0, 3);
        radius = Screen.width;
        angle = Random.Range(0, 360);
        rad = angle * Mathf.Deg2Rad;
        rx = Mathf.Cos(rad) * radius;
        ry = Mathf.Sin(rad) * radius;
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //if (!timer.IsGameOver())//ŠÔØ‚ê‚ÅÁ‚·
        //{
        //    Destroy(this.gameObject);
        //}
       
        Debug.Log(screenCenter);
        if (!isEated)
        {
            if (howToMove == 0) transform.position = Vector3.Lerp(transform.position, screenCenter, speed/4 * Time.deltaTime);
            if (howToMove == 1) transform.position = Vector3.Slerp(transform.position, screenCenter, speed/4 * Time.deltaTime);
            if (howToMove == 2) transform.position = Vector3.MoveTowards(transform.position, screenCenter, speed*4 * Time.deltaTime);
        }
        else
        {
            if(howToEscape==0)transform.position=Vector3.Lerp(transform.position,new Vector3(rx,ry,0),speed*Time.deltaTime);
            if(howToEscape==1)transform.position=Vector3.Slerp(transform.position,new Vector3(rx,ry,0),speed*Time.deltaTime);
            if(howToEscape==2)transform.position=Vector3.MoveTowards(transform.position,new Vector3(rx,ry,0),speed*Time.deltaTime);
            if (Vector3.Distance(this.transform.position,screenCenter)> 10f)//‰æ–Ê’†‰›‚©‚çworldÀ•W‚Å10ˆÈã—£‚ê‚½‚çÁ‚·
            {
                Destroy(this.gameObject);
            }
        }
        pos = Vector3.Distance(transform.position, screenCenter);//’†‰›‚É—ˆ‚½‚©Šm‚©‚ß‚é‚½‚ß‚Ì•Ï”
        if(pos<1) isEated = true;        
    }
    public void OnClick()
    {
        Destroy(this.gameObject);
        instantiateInsect.catchCount++;
        Debug.Log(instantiateInsect.catchCount);
    }
}
