using UnityEngine;

public class ImageSourceSelector : MonoBehaviour
{
    public CameraGalleryPicker cameraGalleryPicker;

    public void ShowOptions()
    {
#if UNITY_EDITOR
        // Editörde test için galeri kullan
        cameraGalleryPicker.OpenGallery();
#else
        // Android/iOS: Native UI yerine basit seçim
        // Geliştikçe buraya Action Sheet gibi bir seçenek eklenebilir
        cameraGalleryPicker.OpenGallery();
#endif
    }
}
