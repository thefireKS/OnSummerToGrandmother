using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{ 
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetVisit(int sceneNumber)
    {
        FindObjectOfType<VisitedActivitiesManager>().SetSceneVisited(sceneNumber);
    }
}
