using UnityEngine;

public class PopUpPanelController : MonoBehaviour
{
    public CanvasGroup popupGroup;
    public GameObject nextButton;

    public void ShowPanel()
    {
        popupGroup.alpha = 1f;
        popupGroup.interactable = true;
        popupGroup.blocksRaycasts = true;

        if (nextButton != null)
            nextButton.SetActive(false);

        Debug.Log("Panel gösterildi");
    }

    public void HidePanel()
    {
        popupGroup.alpha = 0f;
        popupGroup.interactable = false;
        popupGroup.blocksRaycasts = false;

        if (nextButton != null)
            nextButton.SetActive(true);

        Debug.Log("Panel gizlendi");
    }
}
