using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class EditOCRManager : MonoBehaviour
{
    public RawImage previewImage;

    void Start()
    {
        string path = PlayerPrefs.GetString("LastImagePath", "");
        Debug.Log("OCR sahnesine gelen yol: " + path);

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            // Dosya sisteminden Texture2D yükle
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(path));

            Debug.Log("Yüklenen texture null mu? " + (texture == null));
            if (texture != null)
            {
                previewImage.texture = texture;

                // AspectRatioFitter ile oranı koru
                AspectRatioFitter fitter = previewImage.GetComponent<AspectRatioFitter>();
                if (fitter != null)
                {
                    float aspect = (float)texture.width / texture.height;
                    fitter.aspectRatio = aspect;
                }
            }
        }
        else
        {
            Debug.LogWarning("Görsel yolu geçerli değil veya dosya bulunamadı.");
        }
    }

    public void ProcessOCR()
    {
        Debug.Log("OCR başlatılıyor...");
        // OCR işlemine burada başlanır (örnek: Tesseract entegrasyonu)
    }

    public void GoBackToQuizCreation()
    {
        SceneManager.LoadScene("Quiz_Creation");
    }

    public void ChooseNewImage()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (!string.IsNullOrEmpty(path))
            {
                PlayerPrefs.SetString("LastImagePath", path);
                SceneManager.LoadScene("EditOCRScene");
            }
        }, "Yeni bir görsel seç", "image/*");
    }
}
