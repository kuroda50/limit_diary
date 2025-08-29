using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{

    public static SEManager instance;

    [SerializeField] AudioSource seAudioSource;
    [SerializeField] public AudioClip[] SEClips; // 再生したいSEのリスト

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
        seAudioSource.volume = 0.2f;
    }

    // ボリューム変更
    public void SetSeVolume(float volume)
    {
        seAudioSource.volume = volume;
    }
    public void PlaySE(int index)
    {
        // 指定された番号がリストの範囲内かチェック
        if (index < 0 || index >= SEClips.Length)
        {
            Debug.LogWarning("SEの指定番号が範囲外です。");
            return;
        }

        // 再生するSEクリップを取得
        AudioClip newClip = SEClips[index];

        // SEを差し替えて再生
        seAudioSource.clip = newClip;
        seAudioSource.Play();
    }
}