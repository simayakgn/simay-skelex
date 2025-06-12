using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraGalleryPicker : MonoBehaviour
{
    public UnityEngine.Camera captureCamera;
    public UnityEngine.RenderTexture renderTexture;

    public void OpenCamera()
    {
        if (captureCamera == null || renderTexture == null)
        {
            Debug.LogError("Kamera veya RenderTexture atanmamış!");
            return;
        }

        // Mevcut render hedefini kaydet
        RenderTexture currentRT = RenderTexture.active;

        // Kameraya RenderTexture'u hedef olarak ata
        RenderTexture.active = renderTexture;
        captureCamera.targetTexture = renderTexture;

        // Kamerayı render et
        captureCamera.Render();

        // Textur2D oluştur ve render edilmiş görüntüyü içine oku
        Texture2D image = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        image.Apply();

        // Ayarları eski haline getir
        RenderTexture.active = currentRT;
        captureCamera.targetTexture = null;

        // PNG olarak kaydet
        byte[] bytes = image.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "captured_image.png");
        File.WriteAllBytes(path, bytes);
        Debug.Log("Image saved to: " + path);

        PlayerPrefs.SetString("LastImagePath", path);
        SceneManager.LoadScene("EditOCRScene");
    }

    public void OpenGallery()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (!string.IsNullOrEmpty(path))
            {
                PlayerPrefs.SetString("LastImagePath", path);
                SceneManager.LoadScene("EditOCRScene");
            }
        }, "Resim Seç", "image/*");
    }
}
