using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedActivitiesFunctions : MonoBehaviour
{
    public void SetSceneVisited(int sceneNumber)
    {
        VisitedActivitiesManager.instance.places[sceneNumber] = true;
    }

    public void SetSceneUnVisited(int sceneNumber)
    {
        VisitedActivitiesManager.instance.places[sceneNumber] = false;
    }
}
