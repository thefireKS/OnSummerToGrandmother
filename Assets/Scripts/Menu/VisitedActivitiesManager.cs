using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedActivitiesManager : MonoBehaviour
{
    public List<bool> places = new List<bool>(); //0 - Currant, 1 - Mint, 2 - Apples;

    public static VisitedActivitiesManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SetSceneVisited(int sceneNumber)
    {
        places[sceneNumber] = true;
    }
}
