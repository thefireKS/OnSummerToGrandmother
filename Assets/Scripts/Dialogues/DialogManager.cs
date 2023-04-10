using System;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject mainDialogObject;
    [Space(5)]
    [SerializeField] private DialogSet[] dialogues;
    private static int currentDialogNumber = 0;
    
    [Serializable]
    public struct DialogSet
    {
        public GameObject mainDialog;
        public GameObject trueDialogEnd;
        public GameObject falseDialogEnd;
    }

    private void Start()
    {
        dialogues[currentDialogNumber].mainDialog.SetActive(true);
    }

    private void OnEnable()
    {
        TeaComparer.StartTrueDialog += TrueDialog;
        TeaComparer.StartFalseDialog += FalseDialog;
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
