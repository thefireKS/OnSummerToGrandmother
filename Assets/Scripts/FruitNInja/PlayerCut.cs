using UnityEngine;

public class PlayerCut : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void OnEnable()
    {
        FruitNinjaScoreManager.win += Stop;
    }

    private void OnDisable()
    {
        FruitNinjaScoreManager.win -= Stop;
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
        {
            player.SetActive(false);
        }
        else
        {
            player.SetActive(true);
            Touch touch = Input.GetTouch(0);
            Vector3 newPosition = _mainCamera.ScreenToWorldPoint(touch.position);
            newPosition.z = 0;
            player.transform.position = newPosition;   
        }
    }

    private void Stop()
    {
        Destroy(gameObject);
    }
}
