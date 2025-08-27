using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public sealed class MarkerUI : MonoBehaviour
{
    Image image_;

    [Header("OnMoveMarkerAnimation")]
    [SerializeField] float moveSpeed_ = 1f;
    [SerializeField] float cancelMoveDistance_ = 1f;
    [SerializeField] float moveCooldown_ = 0.1f;

    [Header("OnDisappearAnimation")]
    [SerializeField, Range(0, 1)] float disappearSpeed_ = 0.01f;

    [Header("OnAppeaerAnimation")]
    [SerializeField, Range(0, 1)] float appearSpeed_ = 0.01f;

    private void Awake()
    {
        image_ = GetComponent<Image>();
    }

    public IEnumerator OnDisappearAnimationAsync()
    {
        for (float alpha = 1; alpha > 0; alpha -= disappearSpeed_)
        {
            image_.color = new Color(image_.color.r, image_.color.g, image_.color.b, alpha);
            yield return null;
        }
    }

    public IEnumerator OnAppearAnimationAsync()
    {
        for (float alpha = 0; alpha < 1; alpha += disappearSpeed_)
        {
            image_.color = new Color(image_.color.r, image_.color.g, image_.color.b, alpha);
            yield return null;
        }
    }

    public IEnumerator OnMoveAsync(Vector3 nextPos)
    {
        while (true)
        {
            var moveDirection = nextPos - transform.position;

            if (moveDirection.magnitude < 2)
                break;

            transform.position += moveDirection.normalized * moveSpeed_;
            yield return null;
        }
        
        yield return new WaitForSeconds(moveCooldown_);
    }

    public IEnumerator OnScaleAttensionAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int scale = 0; scale < 100; scale++)
            {
                transform.localScale += new Vector3(0.003f, 0.003f);
                yield return null;
            }

            for (int scale = 100; scale > 0; scale--)
            {
                transform.localScale -= new Vector3(0.003f, 0.003f);
                yield return null;
            }
        }
    }
}
