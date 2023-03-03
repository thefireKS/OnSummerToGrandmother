using System;
using UnityEngine;

public class Secateur : MonoBehaviour
{
    [SerializeField] private GameObject secateur;

    [SerializeField] private float timeToReachNewPoint;
    private float elapsedTime;

    private Vector3 _targetPosition, _startPosition;

    private bool _reachNewPosition;

    private Camera _mainCamera;

    private Animator _animator;

    private void Awake()
    {
        Cursor.visible = false;
        _mainCamera = Camera.main;
        _animator = secateur.GetComponent<Animator>();
        _startPosition = transform.position;
        _targetPosition = _startPosition;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / timeToReachNewPoint;

        transform.position = Vector3.Lerp(_startPosition, _targetPosition, Mathf.SmoothStep(0, 1, percentageComplete));
        if (transform.position == _targetPosition)
        {
            _startPosition = _targetPosition;
            if(_reachNewPosition) _animator.Play("Cut");
            _reachNewPosition = false;
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (_mainCamera != null)
            {
                if (_reachNewPosition) return;
                Vector3 newTargetPosition = new Vector3(_mainCamera.ScreenToWorldPoint(touch.position).x,
                    _mainCamera.ScreenToWorldPoint(touch.position).y, 10);
                _targetPosition = newTargetPosition;
                elapsedTime = 0;
                _reachNewPosition = true;
            }
        }
    }
}
