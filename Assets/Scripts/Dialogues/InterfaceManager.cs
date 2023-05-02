using System;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject mainDialogObject;
    [Space(5)]
    [SerializeField] private DialogElements[] dialogElements;
    
    private GameObject[] _disableOnDialogStart;

    private int _currentAnswer;
    
    [Serializable]
    public struct DialogElements
    {
        public GameObject mainDialogObject;
        public List<GameObject> dialogParts;
        public List <GameObject> questions;
    }

    private void OnEnable()
    {
        _disableOnDialogStart = GameObject.FindGameObjectsWithTag("TeaMaking");
        TypewriterEffect.activateQuestion += ActivateAnswerWindow;
        TypewriterEffect.startTeaMaking += ActivateTeaMaking;
        TeaMakingSwitch();
        DisableDialog();

        _currentAnswer = 0;
        Debug.Log(DialogManager.currentDialogNumber);
        dialogElements[DialogManager.currentDialogNumber].mainDialogObject.SetActive(true);
    }

    private void OnDisable()
    {
        TypewriterEffect.activateQuestion -= ActivateAnswerWindow;
        TypewriterEffect.startTeaMaking -= ActivateTeaMaking;
    }

    private void ActivateAnswerWindow()
    {
        DisableAllQuestions();
        DisableDialogParts();
        dialogElements[DialogManager.currentDialogNumber].questions[_currentAnswer].SetActive(true);
        _currentAnswer++;
    }

    private void ActivateTeaMaking()
    {
        DisableAllQuestions();
        DisableDialog();
        TeaMakingSwitch();
        mainDialogObject.SetActive(false);
    }

    private void TeaMakingSwitch()
    {
        foreach (var obj in _disableOnDialogStart)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    private void DisableAllQuestions()
    {
        foreach (var que in dialogElements[DialogManager.currentDialogNumber].questions)
        {
            que.SetActive(false);
        }
    }

    private void DisableDialog()
    {
        foreach (var obj in dialogElements)
        {
            obj.mainDialogObject.SetActive(false);
        }
    }

    private void DisableDialogParts()
    {
        foreach (var obj in dialogElements[DialogManager.currentDialogNumber].dialogParts)
        {
            obj.SetActive(false);
        }
    }
}
