using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsManager : MonoBehaviour
{ 
    [SerializeField] private List <Ingredients> ingredients;
    
    [Serializable]
    private struct Ingredients
    {
        public int numberOfVisitedScene;
        public GameObject[] toEnableOnVisit;
        public GameObject[] toDisableOnVisit;
    }

    private void Start()
    {
        var _vam = VisitedActivitiesManager.instance;
        
        foreach (var ing in ingredients)
        {
            if (_vam.places[ing.numberOfVisitedScene])
            {
                Debug.Log("?");
                foreach (var enIng in ing.toEnableOnVisit)
                {
                    enIng.SetActive(true);
                }

                foreach (var disIng in ing.toDisableOnVisit)
                {
                    disIng.SetActive(false);
                }
            }
            else
            {
                foreach (var enIng in ing.toEnableOnVisit)
                {
                    enIng.SetActive(false);
                }

                foreach (var disIng in ing.toDisableOnVisit)
                {
                    disIng.SetActive(true);
                }
            }
        }
    }
}
