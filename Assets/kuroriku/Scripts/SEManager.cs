using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{

    public static SEManager instance;

    [SerializeField] AudioSource seAudioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // ボリューム変更
    public void SetSeVolume(float volume)
    {
        seAudioSource.volume = volume;
    }
    // クリップを受け取ってSEを鳴らす
    public void PlaySE(AudioClip clip)
    {
        seAudioSource.PlayOneShot(clip);
    }
}