using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NetObject : MonoBehaviour
{
    [SerializeField] int count = 0;

    private void FixedUpdate()
    {
        count++;

        if(count > 35)
        {
            Destroy(gameObject);
        }
    }
}
