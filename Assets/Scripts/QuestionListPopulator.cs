using UnityEngine;
using TMPro;

public class QuestionListPopulator : MonoBehaviour
{
    [Header("Prefab ve Parent Ayarları")]
    public GameObject questionItemPrefab;
    public Transform userQuestionsContent;

    public void AddQuestionItem(string id, string question, string[] answers, char correct)
    {
        GameObject item = Instantiate(questionItemPrefab, userQuestionsContent);

        item.transform.Find("QuestionText").GetComponent<TMP_Text>().text = question;
        item.transform.Find("AnswerAText").GetComponent<TMP_Text>().text = "A) " + answers[0];
        item.transform.Find("AnswerBText").GetComponent<TMP_Text>().text = "B) " + answers[1];
        item.transform.Find("AnswerCText").GetComponent<TMP_Text>().text = "C) " + answers[2];
        item.transform.Find("AnswerDText").GetComponent<TMP_Text>().text = "D) " + answers[3];
        item.transform.Find("AnswerEText").GetComponent<TMP_Text>().text = "E) " + answers[4];
        item.transform.Find("CorrectAnswerText").GetComponent<TMP_Text>().text = "Doğru Cevap: " + correct;
    }

    void Start()
    {
        string[] testOptions = { "Humerus", "Femur", "Radius", "Tibia", "Ulna" };
        AddQuestionItem("USR001", "İnsan vücudundaki en uzun kemik hangisidir?", testOptions, 'B');
    }
}
