using System;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int score;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) return;
        if(collision.gameObject.CompareTag("Basket")) GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().AddScore(score);
        Destroy(gameObject);
    }
}
