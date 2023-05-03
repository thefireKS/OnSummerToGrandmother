using System;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int score;

    public static Action<int> giveScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) return;
        if (collision.gameObject.CompareTag("Basket"))
            giveScore?.Invoke(score);
        Destroy(gameObject);
    }
}
