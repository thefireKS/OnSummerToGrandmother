using System;
using UnityEngine;

public class Secateur_GetData : MonoBehaviour
{
    [SerializeField] private Transform parentSecateur;

    private void GetData()
    {
        var position = parentSecateur.position;
        Vector2 ray = new Vector2(position.x, position.y);
        RaycastHit2D hit = Physics2D.Raycast(ray, ray);
        if (hit.collider != null)
        {
            Rigidbody2D _rb2d = hit.collider.gameObject.AddComponent<Rigidbody2D>();
            if(hit.collider.gameObject.name[0] == 'm') _rb2d.gravityScale = -1;
        }
    }
}
