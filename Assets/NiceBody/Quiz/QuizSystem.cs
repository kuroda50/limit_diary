using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class QuizSystem : MonoBehaviour
{
    [Header("Model")]
    [SerializeField] QuizStatusGroup quizStatusGroup_;
    [SerializeField] List<QuizStatus> appearedQuizzes_ = new();
    [SerializeField] int maxAppearQuizCount_ = 10;
    [SerializeField] int appearQuizCount_ = 0;

    [Header("View")]
    [SerializeField] Canvas quizCanvas;
    [SerializeField] Image dateImageBox_;
    [SerializeField] AnswerCnadiateUiGroup answerCandiateUiGroup_;
    [SerializeField] Text topicTextBox_;

    [Header("answerCharactorView")]
    [SerializeField] Image answerCharactorImage_;
    [SerializeField] Sprite correctAnswerCharactorSprite_;
    [SerializeField] Sprite wrongAnswerCharactorSprite_;
    [SerializeField] Sprite stayAnswerCharactorSprite_;

    [Header("ResultView")]
    [SerializeField] Canvas resultCanvas;


    private void Start()
    {
        OnAskQuiz();
    }

    private void OnAskQuiz()
    {
        var quiz = quizStatusGroup_.GetRandomQuizStatus(appearedQuizzes_);
        appearQuizCount_++;
        appearedQuizzes_.Add(quiz);

        answerCharactorImage_.sprite = stayAnswerCharactorSprite_;
        dateImageBox_.sprite = quiz.DateSprite;
        topicTextBox_.text = quiz.TopicText;

        var zipped = quiz.AnswerCandiates.Zip(answerCandiateUiGroup_.Get, (answer, ui) => (answer, ui));

        foreach (var (answer, ui) in zipped)
        {
            ui.TextBox.text = answer.Text;
            ui.Button.onClick.AddListener(() => StartCoroutine(OnAnswerSelect(answer)));
        }

        IEnumerator OnAnswerSelect(QuizStatus.AnswerCandidate answer)
        {
            zipped.ToList().ForEach(t => t.ui.Button.onClick.RemoveAllListeners());

            if (quiz.CorrectAnswerIndex == quiz.AnswerCandiates.IndexOf(answer))
            {
                answerCharactorImage_.sprite = correctAnswerCharactorSprite_;
                Debug.Log("Correct!");
            }
            else
            {
                answerCharactorImage_.sprite = wrongAnswerCharactorSprite_;
                Debug.Log("Wrong...");
            }

            yield return new WaitForSeconds(1.0f);

            if (maxAppearQuizCount_ > appearQuizCount_)
            {   
                OnAskQuiz();
            }
            else
            {
                OnMigrateResult();
            }
        }
    }

    private IEnumerator OnMigrateResult()
    {
        yield return new WaitForSeconds(0.8f);

        quizCanvas.enabled = false;
        resultCanvas.enabled = true;

        
    }
}
