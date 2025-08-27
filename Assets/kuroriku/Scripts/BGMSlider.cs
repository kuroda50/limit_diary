using UnityEngine;

public class BGMSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
      BGMManager.instance.SetBGMVolume(volume);
    }
}