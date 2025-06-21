using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class ToggleManager : MonoBehaviour
{
    public GameObject questionTogglePrefab;

    public Transform questionsPanel;       // Hazır sorular → ReadyQuestionsScroll/Content
    public Transform userQuestionsPanel;   // OCR'dan gelenler → UserQuestionsScroll/Content

    public GameObject nextButton;

    public QuestionList questionListSO;
    public OcrQuestionList ocrQuestionListSO;
    public SelectedQuestionsList selectedQuestionsListSO;

    private List<Toggle> allToggles = new List<Toggle>();
    private List<QuizQuestion> allQuestions = new List<QuizQuestion>();

    void Start()
    {
        nextButton.SetActive(false);

        // Hazır soruları yükle
        AddTogglesFromList(questionListSO.questionList, questionsPanel);

        // OCR'dan gelenleri yükle (overload fonksiyonu ile)
        AddTogglesFromList(ocrQuestionListSO, userQuestionsPanel);

        if (selectedQuestionsListSO == null)
        {
            Debug.LogError("selectedQuestionsListSO is NULL!");
        }
        else
        {
            Debug.Log("selectedQuestionsListSO is OK");
        }
    }

    void AddTogglesFromList(List<QuizQuestion> sourceList, Transform targetPanel)
    {
        foreach (var question in sourceList)
        {
            CreateToggle(question, targetPanel);
        }
    }

    void AddTogglesFromList(OcrQuestionList sourceList, Transform targetPanel)
    {
        foreach (var question in sourceList.questionList)
        {
            CreateToggle(question, targetPanel);
        }
    }

    void CreateToggle(QuizQuestion question, Transform targetPanel)
    {
        GameObject toggleObj = Instantiate(questionTogglePrefab, targetPanel);
        Toggle toggle = toggleObj.GetComponent<Toggle>();

        if (toggle == null)
        {
            Debug.LogError("Toggle prefab içinde Toggle bileşeni yok!");
            return;
        }

        TMP_Text label = toggleObj.GetComponentInChildren<TMP_Text>();
        if (label != null)
        {
            label.text = question.QuestionText;
        }
        else
        {
            Debug.LogError("Toggle prefab içinde TMP_Text bileşeni bulunamadı.");
        }

        toggle.onValueChanged.AddListener((isOn) => CheckToggleStates());
        allToggles.Add(toggle);
        allQuestions.Add(question);
    }

    public void CheckToggleStates()
    {
        bool atLeastOneActive = false;

        foreach (Transform child in questionsPanel)
        {
            Toggle toggle = child.GetComponentInChildren<Toggle>();
            if (toggle != null && toggle.isOn)
            {
                atLeastOneActive = true;
                break;
            }
        }

        foreach (Transform child in userQuestionsPanel)
        {
            Toggle toggle = child.GetComponentInChildren<Toggle>();
            if (toggle != null && toggle.isOn)
            {
                atLeastOneActive = true;
                break;
            }
        }

        nextButton.SetActive(atLeastOneActive); // Aktif toggle varsa butonu aç
    }


    public void OnNextClicked()
    {
        if (selectedQuestionsListSO == null)
        {
            Debug.LogError("selectedQuestionsListSO is NULL!");
            return;
        }

        selectedQuestionsListSO.Clear();

        for (int i = 0; i < allToggles.Count; i++)
        {
            if (allToggles[i].isOn)
            {
                selectedQuestionsListSO.AddQuestion(allQuestions[i]);
                Debug.Log("Seçilen soru: " + allQuestions[i].QuestionText);
            }
        }

        // Scene geçişi buraya eklenebilir:
        // SceneManager.LoadScene("NextSceneName");
    }
}
