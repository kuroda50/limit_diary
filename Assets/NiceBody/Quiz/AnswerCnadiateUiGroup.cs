using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AnswerCnadiateUiGroup : MonoBehaviour
{
    [SerializeField] List<AnswerCandidateUi> answerCandidateUis;

    public List<AnswerCandidateUi> Get => answerCandidateUis;
}
