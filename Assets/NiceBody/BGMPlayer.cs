using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BGMPlayer : MonoBehaviour
{
    [SerializeField] private int playBgmIndex = 0;



    private void Start()
    {
        BGMManager.instance.PlayBGM(playBgmIndex);
    }
}
