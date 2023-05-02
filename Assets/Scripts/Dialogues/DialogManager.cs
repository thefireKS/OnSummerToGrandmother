using System;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject mainDialogObject;
    [Space(5)]
    [SerializeField] private DialogSet[] dialogues;
    public static int currentDialogNumber = 0;
    
    [Serializable]
    public struct DialogSet
    {
        public GameObject mainDialog;
        public GameObject trueDialogEnd;
        public GameObject falseDialogEnd;
    }

    private void OnEnable()
    {
        TeaComparer.StartTrueDialog += TrueDialog;
        TeaComparer.StartFalseDialog += FalseDialog;
        
        if (currentDialogNumber > dialogues.Length - 1)
            currentDialogNumber = 0;
        dialogues[currentDialogNumber].mainDialog.SetActive(true);
    }
    
    private void OnDisable()
    {
        TeaComparer.StartTrueDialog -= TrueDialog;
        TeaComparer.StartFalseDialog -= FalseDialog;
    }

    private void TrueDialog()
    {
        mainDialogObject.SetActive(true);
        dialogues[currentDialogNumber].mainDialog.SetActive(false);
        dialogues[currentDialogNumber].trueDialogEnd.SetActive(true);
    }

    private void FalseDialog()
    {
        mainDialogObject.SetActive(true);
        dialogues[currentDialogNumber].mainDialog.SetActive(false);
        dialogues[currentDialogNumber].falseDialogEnd.SetActive(true);
    }
}
