using UnityEngine;

public class Basket : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float speed;
    private Vector2 _move;

    private float _currentWidth;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentWidth = Screen.currentResolution.width;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Movement(touch);
        }
    }

    private void Movement(Touch touch)
    {
        float xPosition = touch.position.x;
        _rigidbody.velocity = xPosition < _currentWidth / 2 ? new Vector2(-speed, 0) : new Vector2(speed, 0);
        if (touch.phase == TouchPhase.Ended)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
