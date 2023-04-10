using System;
using UnityEngine;
using UnityEngine.UI;

public class SwapRoles : MonoBehaviour
{
    [SerializeField] private Canvas guest;
    private Image guestImage;
    [SerializeField] private Canvas ale;
    private Image aleImage;
    [Space(5)] 
    [SerializeField] private Color disabledColor;

    private void Start()
    {
        guestImage = guest.gameObject.GetComponent<Image>();
        aleImage = ale.gameObject.GetComponent<Image>();
    }

    public void ChangePriorities()
    {
        if (guest.sortingOrder == 3) {
            guest.sortingOrder = 1;
            guestImage.color = disabledColor;
            ale.sortingOrder = 3;
            aleImage.color = Color.white;
        } else {
            ale.sortingOrder = 1;
            aleImage.color = disabledColor;
            guest.sortingOrder = 3;
            guestImage.color = Color.white;
        }
    }
}
