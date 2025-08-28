using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject OriginCollider;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private GameObject[] Character;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            Instantiate(OriginCollider, spawnPosition, Quaternion.identity);
        }
    }
    void Start()
    {
        Character[0].SetActive(true);
        Character[1].SetActive(false);
    }

    public void SwingBat() 
    {
        StartCoroutine(ShowObjectTemporarily());
        SEManager.instance.PlaySE(6);
    }
    IEnumerator ShowObjectTemporarily()
    {
        Character[0].SetActive(false);
        Character[1].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Character[0].SetActive(true);
        Character[1].SetActive(false);
    }
    
}
