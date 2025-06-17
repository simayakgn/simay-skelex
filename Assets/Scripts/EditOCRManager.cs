using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditOCRManager : MonoBehaviour
{
    public RawImage previewImage;

    void Start()
    {
        string path = PlayerPrefs.GetString("LastImagePath", "");
        if (!string.IsNullOrEmpty(path))
        {
            Texture2D texture = NativeGallery.LoadImageAtPath(path, 2048);
            if (texture != null)
            {
                previewImage.texture = texture;

                AspectRatioFitter fitter = previewImage.GetComponent<AspectRatioFitter>();
                if (fitter != null)
                    fitter.aspectRatio = (float)texture.width / texture.height;
            }
        }
    }

    public void GoBackToQuizCreation()
    {
        SceneManager.LoadScene("Quiz_Creation");
    }
}
