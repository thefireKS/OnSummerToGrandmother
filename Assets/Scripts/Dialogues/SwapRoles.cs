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
        (guest.sortingOrder, ale.sortingOrder) = (ale.sortingOrder, guest.sortingOrder);
        (guestImage.color, aleImage.color) = (aleImage.color, guestImage.color);
    }
}
