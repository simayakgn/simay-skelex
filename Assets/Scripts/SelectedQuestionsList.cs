using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedQuestionsList", menuName = "ScriptableObjects/SelectedQuestionsList")]
public class SelectedQuestionsList : ScriptableObject
{
    public List<QuizQuestion> selectedQuestions = new List<QuizQuestion>();

    public void Clear()
    {
        if (selectedQuestions == null)
        {
            Debug.LogError("selectedQuestionsListSO.selectedQuestions is NULL!");
            selectedQuestions = new List<QuizQuestion>();
        }
        else
        {
            selectedQuestions.Clear();
        }
    }

    public void AddQuestion(QuizQuestion question)
    {
        selectedQuestions.Add(question);
    }

}
