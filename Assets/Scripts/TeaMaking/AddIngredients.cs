using UnityEngine;
using UnityEngine.UI;

public class AddIngredients : MonoBehaviour
{
    [SerializeField] private TeaData playerTea;
    [Space(5)] 
    [SerializeField] private GameObject fire;
    [Space(5)] [SerializeField] private GameObject tap1; 
    [SerializeField] private GameObject tap2;
    [Space(5)] 
    [SerializeField] private Animator teaPouring;

    
    private bool isPouring = false;

    private void OnEnable()
    {
        playerTea.type = TeaData.TeaType.none;
        playerTea.ingredients.Clear();
        LightFire();
    }

    public void AddIngredient(string ingredientName)
    {
        if(!playerTea.ingredients.Contains(ingredientName))
            playerTea.ingredients.Add(ingredientName);
    }

    public void SetBlackTea()
    {
        playerTea.type = TeaData.TeaType.black;
    }

    public void SetGreenTea()
    {
        playerTea.type = TeaData.TeaType.green;
    }

    public void LightFire()
    {
        fire.SetActive(true);
    }

    public void PourTea()
    {
        if(!fire.activeSelf) return;
        if (playerTea.type != TeaData.TeaType.none)
        {
            PourTumbler();
        }
        if(playerTea.type != TeaData.TeaType.none && isPouring)
            teaPouring.Play(playerTea.type.ToString());
        else
            teaPouring.StopPlayback();
    }

    private void PourTumbler()
    {
        isPouring = !isPouring;
        tap1.SetActive(!tap1.activeSelf);
        tap2.SetActive(!tap2.activeSelf);
    }

    public void ResetTea()
    {
        playerTea.type = TeaData.TeaType.none;
        playerTea.ingredients.Clear();
        teaPouring.Play("New State");

        isPouring = false;
        tap1.SetActive(true);
        tap2.SetActive(false);
        LightFire();
    }
}
