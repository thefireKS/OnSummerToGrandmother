using UnityEngine;

public class Basket : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float speed;
    private Vector2 _move;

    private Camera _camera;

    private bool _stop;

    private void OnEnable()
    {
        CatchApplesScoreManager.win += Stop;
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_stop) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Movement(touch);
        }
    }

    private void Movement(Touch touch)
    {
        Vector3 positionBasket = transform.position;
        positionBasket = _camera.WorldToScreenPoint(positionBasket);
        float xPosition = touch.position.x;
        _rigidbody.velocity = xPosition < positionBasket.x ? new Vector2(-speed, 0) : new Vector2(speed, 0);
        if (touch.phase == TouchPhase.Ended || Mathf.Abs(xPosition - positionBasket.x) < 10f)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
    
    private void Stop()
    {
        _stop = true;
    }
}
