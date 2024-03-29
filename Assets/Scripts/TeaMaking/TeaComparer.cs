using System;
using UnityEngine;

public class TeaComparer : MonoBehaviour
{
    [SerializeField] private TeaData PlayerTea;
    [Space(10)] 
    [SerializeField] private TeaData[] rightTeas;

    public static Action StartTrueDialog, StartFalseDialog;

    public void CheckTea()
    {
        if(PlayerTea.type == TeaData.TeaType.none)
            return;
        
        if(PlayerTea == rightTeas[DialogManager.currentDialogNumber])
            StartTrueDialog?.Invoke();
        else
            StartFalseDialog?.Invoke();

        DialogManager.currentDialogNumber++;
    }
}