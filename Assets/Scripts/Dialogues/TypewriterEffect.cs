using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    [Space(5)]
    [SerializeField] private float delay = 0.05f;
    [SerializeField] private string fullText;
    
    private string currentText = "";

    private int length = 1;
    private int currentPhraseID = 1;

    private float currentTime = 0f;

    public static Action activateQuestion;
    public static Action startTeaMaking;
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (!(currentTime > delay) || (fullText == currentText)) return;
        currentText = fullText[..length];
        length++;
        currentTime = 0f;
        textField.text = currentText;
    }

    public void UpdateText(string newText)
    {
        if(newText[..1] != currentPhraseID.ToString()) return;
        var sText = newText[1..];
        switch (sText)
        {
            case "Question":
                activateQuestion?.Invoke();
                break;
            case "StartTea":
                startTeaMaking?.Invoke();
                break;
            case "MainScene":
                SceneManager.LoadScene("MainGame");
                break;
        }
        textField.text = "";
        fullText = sText;
        currentText = "";
        length = 1;
    }

    public void UpdatePhraseID()
    {
        currentPhraseID++;
    }
}
