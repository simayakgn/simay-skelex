using UnityEngine;

public class PopUpPanelController : MonoBehaviour
{
    public CanvasGroup popupGroup;

    public void ShowPanel()
    {
        popupGroup.alpha = 1f;
        popupGroup.interactable = true;
        popupGroup.blocksRaycasts = true;

        Debug.Log("Panel gösterildi");
    }

    public void HidePanel()
    {
        popupGroup.alpha = 0f;
        popupGroup.interactable = false;
        popupGroup.blocksRaycasts = false;

        Debug.Log("Panel gizlendi");
    }
}
