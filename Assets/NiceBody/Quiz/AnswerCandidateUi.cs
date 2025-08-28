using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class AnswerCandidateUi : MonoBehaviour
{
    Image   image_;
    Button  button_;
    [SerializeField] Text textBox_;

    public Image    Image_  => image_;
    public Text     TextBox => textBox_;
    public Button   Button => button_;


    private void Awake()
    {
        image_  = GetComponent<Image>();
        button_ = GetComponent<Button>();
    }
}
