using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizStatusGroup", menuName = "Scriptable Objects/QuizStatusGroup")]
public class QuizStatusGroup : ScriptableObject
{
    [SerializeField] List<QuizStatus> quizzes;

    public QuizStatus GetRandomQuizStatus(IReadOnlyCollection<QuizStatus> excludeQuiz)
    {
        var filtered = quizzes
            .Where(q => !excludeQuiz.Contains(q))
            .ToList();

        return filtered[UnityEngine.Random.Range(0, filtered.Count)];
    }

}
