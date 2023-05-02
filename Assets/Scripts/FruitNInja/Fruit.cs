using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject leftPart, rightPart;
    private Rigidbody2D _leftPartRb, _rightPartRb;

    [SerializeField] private float cutForce;

    private void Start()
    {
        _leftPartRb = leftPart.GetComponent<Rigidbody2D>();
        _rightPartRb = rightPart.GetComponent<Rigidbody2D>();

        Destroy(gameObject, 15f);
        Destroy(leftPart, 15f);
        Destroy(rightPart, 15f);
    }

    private void CutFruit()
    {
        _leftPartRb.simulated = true;
        _rightPartRb.simulated = true;
        
        leftPart.transform.parent = null;
        rightPart.transform.parent = null;
        
        Vector3 force = -leftPart.transform.right * cutForce;
        force += leftPart.transform.up * cutForce/2;
        _leftPartRb.AddForce(force, ForceMode2D.Impulse);
        
        force = rightPart.transform.right * cutForce;
        force += rightPart.transform.up * cutForce/2;
        _rightPartRb.AddForce(force,ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) CutFruit();
    }
}
