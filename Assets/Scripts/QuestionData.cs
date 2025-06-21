using System;
using System.Collections.Generic;

[Serializable]
public class QuestionData
{
    public string question;
    public List<string> choices = new List<string>();
    public string correctAnswer;
}
