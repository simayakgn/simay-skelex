using System.Collections.Generic;
using UnityEngine;

public class QuestionList : ScriptableObject
{
    public List<QuizQuestion> questionList = new List<QuizQuestion>();

    public void Clear()
    {
        questionList.Clear();
    }

    public void AddQuestion(QuizQuestion question)
    {
        questionList.Add(question);
    }
}
