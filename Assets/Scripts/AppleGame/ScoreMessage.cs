using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMessage : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI messageText;
    private float tickTime = 0.05f, currentTime = 0f;
    private void Awake()
    {
        messageText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (messageText.color.a <= 0)
            Destroy(gameObject);

        currentTime += Time.deltaTime;

        if (currentTime > tickTime)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f);
            messageText.color = new Color(1f, 1f, 1f, messageText.color.a - 0.05f);
            currentTime = 0f;
        }
    }
}
