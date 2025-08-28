using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuizzesStatus", menuName = "Scriptable Objects/QuizzStatus")]
public sealed class QuizStatus : ScriptableObject
{
    [SerializeField] string topicText = "";
    [SerializeField] Sprite dateSprite;
    [SerializeField] List<AnswerCandidate> answerCandiates_ = new();
    [SerializeField] int correctAnswerIndex_ = 0;

    public string TopicText => topicText;
    public Sprite DateSprite => dateSprite;
    public List<AnswerCandidate> AnswerCandiates => answerCandiates_;
    public int CorrectAnswerIndex => correctAnswerIndex_;


    [Serializable]
    public sealed class AnswerCandidate
    {
        [SerializeField] string text;
        [SerializeField] Sprite uiSprite_;

        public string Text => text;
        public Sprite UiSprite => uiSprite_;
    }
}
