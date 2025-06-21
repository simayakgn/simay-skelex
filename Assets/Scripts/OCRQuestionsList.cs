using UnityEngine;

[CreateAssetMenu(fileName = "OcrQuestionList", menuName = "ScriptableObjects/OcrQuestionList")]
public class OcrQuestionList : QuestionList
{
    // QuestionList'ten miras aldığı için yeniden tanımlamaya gerek yok.
    // questionList, Clear(), AddQuestion() zaten ana sınıfta mevcut.
}
