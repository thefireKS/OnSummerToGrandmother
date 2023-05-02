using System.Collections.Generic;
using UnityEngine;

public class PlinkManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> fingers;
    private VisitedActivitiesManager _vam;
    private void Start()
    {
        _vam = FindObjectOfType<VisitedActivitiesManager>();

        for(int i = 0; i < _vam.places.Count; i++)
        {
            fingers[i]?.SetActive(!_vam.places[i]);
        }
    }
}