using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraGalleryPicker : MonoBehaviour
{
    public void OpenCamera()
    {

        NativeCamera.TakePicture((path) =>
        {
            if (string.IsNullOrEmpty(path))
                return;

            // Fotoğraf Android'de geçici DCIM klasöründe olabilir
            string dst = CopyToPersistent(path);
            PlayerPrefs.SetString("LastImagePath", dst);
            SceneManager.LoadScene("EditOCRScene");

        }, maxSize: 2048);
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
        }, "Select an image", "image/*");
    }

    private string CopyToPersistent(string originalPath)
    {
        string filename = System.IO.Path.GetFileName(originalPath);
        string dstPath = System.IO.Path.Combine(Application.persistentDataPath, filename);
        System.IO.File.Copy(originalPath, dstPath, true);
        return dstPath;
    }
}
