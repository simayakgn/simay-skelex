using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void changeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
