using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private SuikaMover[] melons;
    int index;
    [SerializeField] private SceneManeger sceneManeger;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createmelon());
    }

    // Update is called once per frame
    void Update()
    {
        index = Random.Range(0, melons.Length);
    }

    IEnumerator createmelon()
    {
        while (true)
        {
            SuikaMover Object=Instantiate(melons[index]);
            Object.setup(sceneManeger);
            yield return new WaitForSeconds(1);
        }
    }
}
