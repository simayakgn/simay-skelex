using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PreviewEditorManager : MonoBehaviour
{
    private QuestionData currentQuestionData;
    public QuizQuestion targetQuestion; // ScriptableObject referansı


    [SerializeField] private TMP_InputField questionInput;
    [SerializeField] private List<TMP_InputField> choiceInputs;
    [SerializeField] private TMP_InputField correctAnswerInput;

    void Start()
    {
        // ScriptableObject'teki verileri UI'a aktarma
        if (targetQuestion != null)
        {
            questionInput.text = targetQuestion.QuestionText;

            for (int i = 0; i < choiceInputs.Count && i < targetQuestion.Options.Length; i++)
            {
                if (choiceInputs[i] != null)
                    choiceInputs[i].text = targetQuestion.Options[i];
            }

            if (correctAnswerInput != null)
                correctAnswerInput.text = targetQuestion.CorrectAnswer.ToString();
        }

        questionInput.interactable = false;

        foreach (var input in choiceInputs)
        {
            input.interactable = false;
        }

        correctAnswerInput.interactable = false;
    }

    public QuestionData GetEditedQuestionData()
    {
        QuestionData data = new QuestionData();
        data.question = questionInput.text;

        foreach (var input in choiceInputs)
        {
            if (input != null)
                data.choices.Add(input.text);
        }

        data.correctAnswer = correctAnswerInput.text;

        return data;
    }

    public void EnableEditing()
    {
        questionInput.interactable = true;

        foreach (var input in choiceInputs)
        {
            if (input != null)
                input.interactable = true;
        }

        correctAnswerInput.interactable = true;
    }

    public void OnClickContinue()
    {
        currentQuestionData = new QuestionData();
        currentQuestionData.question = questionInput.text;

        currentQuestionData.choices = new List<string>();
        foreach (var input in choiceInputs)
        {
            currentQuestionData.choices.Add(input.text);
        }

        currentQuestionData.correctAnswer = correctAnswerInput.text;

        Debug.Log("Soru: " + currentQuestionData.question);
        for (int i = 0; i < currentQuestionData.choices.Count; i++)
        {
            Debug.Log("Seçenek " + (char)('A' + i) + ": " + currentQuestionData.choices[i]);
        }
        Debug.Log("Doğru Cevap: " + currentQuestionData.correctAnswer);

        // ScriptableObject'e veriyi yaz
        if (targetQuestion != null)
        {
            targetQuestion.QuestionText = currentQuestionData.question;
            targetQuestion.Options = currentQuestionData.choices.ToArray();
            targetQuestion.CorrectAnswer = string.IsNullOrEmpty(currentQuestionData.correctAnswer) ? ' ' : currentQuestionData.correctAnswer.ToUpper()[0];

            Debug.Log("ScriptableObject güncellendi.");
        }
    }
}
