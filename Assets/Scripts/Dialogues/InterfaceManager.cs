using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject mainDialogObject;
    [Space(5)]
    [SerializeField] private GameObject[] dialogWindows;
    [SerializeField] private GameObject[] questions;
    [Space(5)]
    [SerializeField] private GameObject[] disableOnDialogStart;

    private int currentAnswer = 0;
    private void OnEnable()
    {
        TypewriterEffect.activateQuestion += ActivateAnswerWindow;
        TypewriterEffect.startTeaMaking += ActivateTeaMaking;
        TeaMakingSwitch();
    }

    private void OnDisable()
    {
        TypewriterEffect.activateQuestion -= ActivateAnswerWindow;
        TypewriterEffect.startTeaMaking -= ActivateTeaMaking;
    }

    private void ActivateAnswerWindow()
    {
        DisableAllQuestions();
        DisableDialog();
        questions[currentAnswer].SetActive(true);
        currentAnswer++;
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
        foreach (var obj in disableOnDialogStart)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    private void DisableAllQuestions()
    {
        foreach (var que in questions)
        {
            que.SetActive(false);
        }
    }

    private void DisableDialog()
    {
        foreach (var obj in dialogWindows)
        {
            obj.SetActive(false);
        }
    }
}
