using UnityEngine;

public class PlayerCut : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (_mainCamera)
            {
                Vector3 newPosition = _mainCamera.ScreenToWorldPoint(touch.position);
                newPosition.z = 0;
                transform.position = newPosition;
            }
        }
    }
}
