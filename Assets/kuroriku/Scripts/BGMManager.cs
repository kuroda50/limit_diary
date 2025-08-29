using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{

    public static BGMManager instance;

    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] public AudioClip[] bgmClips; // 再生したいBGMのリスト



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        bgmAudioSource.volume = 0.2f;
    }

    public void PlayBGM(int index)
    {
        // 指定された番号がリストの範囲内かチェック
        if (index < 0 || index >= bgmClips.Length)
        {
            Debug.LogWarning("BGMの指定番号が範囲外です。");
            return;
        }

        // 再生するBGMクリップを取得
        AudioClip newClip = bgmClips[index];

        // もし、すでに同じBGMが流れていたら何もしない
        if (bgmAudioSource.clip == newClip)
        {
            return;
        }

        // BGMを差し替えて再生
        bgmAudioSource.clip = newClip;
        bgmAudioSource.Play();
    }

    public void SetBGMVolume(float volume)
    {
        bgmAudioSource.volume = volume;
    }
}