using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class QuizSystem : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] QuizStatusGroup quizStatusGroup;
    [SerializeField] List<QuizStatus> appearedQuizzes = new();
    [SerializeField] int appearQuizCount = 10;

    [Header("View")]
    [SerializeField] AnswerCnadiateUiGroup answerCandiateUiGroup_;
    [SerializeField] Text quizTextBox;


    private void Start()
    {
        OnPlay();
    }

    private void OnPlay()
    {
        var quiz = quizStatusGroup.GetRandomQuizStatus(appearedQuizzes);
        appearedQuizzes.Add(quiz);



        var zipped = quiz.AnswerCandiates.Zip(answerCandiateUiGroup_.Get, (answer, ui) => (answer, ui));

        foreach (var (answer, ui) in zipped)
        {
            ui.Button.onClick.AddListener(() =>
            {
                if (quiz.CorrectAnswerIndex == quiz.AnswerCandiates.IndexOf(answer))
                {
                    Debug.Log("Correct!");
                }
                else
                {
                    Debug.Log("Wrong...");
                }
                zipped.ToList().ForEach(t => t.ui.Button.onClick.RemoveAllListeners());
                OnPlay();
            });
        }
    }
}
