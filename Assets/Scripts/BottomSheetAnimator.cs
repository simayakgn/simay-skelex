using UnityEngine;
using System.Collections;

public class BottomSheetAnimator : MonoBehaviour
{
    public RectTransform panel;
    public float animationTime = 0.3f;

    private float hiddenY;
    private float visibleY;
    private bool isOpen = false;

    void Start()
    {
        float panelHeight = panel.rect.height;
        hiddenY = -panelHeight;
        visibleY = 0f;

        panel.anchoredPosition = new Vector2(0, hiddenY);
        panel.gameObject.SetActive(false);
    }

    public void Show()
    {
        if (isOpen) return;
        isOpen = true;

        panel.gameObject.SetActive(true);
        StartCoroutine(AnimateIn());
    }

    private IEnumerator AnimateIn()
    {
        yield return null; // 1 frame bekle (layout için)

        float panelHeight = panel.rect.height;
        hiddenY = -panelHeight;

        panel.anchoredPosition = new Vector2(0, hiddenY);

        LeanTween.value(panel.gameObject, hiddenY, visibleY, animationTime)
            .setOnUpdate((float val) =>
            {
                panel.anchoredPosition = new Vector2(0, val);
            });
    }
}
