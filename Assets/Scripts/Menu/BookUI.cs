using System;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    [SerializeField] private Transform recipes;

    private List <Transform> r_recipes = new();
    private void Start()
    {
        foreach (Transform recipe in recipes)
        {
            if (recipe.name.StartsWith("R_"))
                r_recipes.Add(recipe);
        }
    }

    public void DisableAllRecipes()
    {
        foreach (var recipe in r_recipes)
        {
            recipe.gameObject.SetActive(false);
        }
    }
}
