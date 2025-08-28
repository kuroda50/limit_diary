using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
