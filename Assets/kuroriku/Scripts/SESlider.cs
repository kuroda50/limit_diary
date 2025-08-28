using UnityEngine;

public class SESlider : MonoBehaviour
{
    public void SetSEVolume(float volume)
    {
      SEManager.instance.SetSeVolume(volume);
    }
}