using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }
}
