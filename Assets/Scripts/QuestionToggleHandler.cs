using UnityEngine;
using UnityEngine.UI;

public class QuestionToggleHandler : MonoBehaviour
{
    public string questionText; // Veya ScriptableObject, ID vs.
    public Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public bool IsSelected()
    {
        return toggle.isOn;
    }
}
