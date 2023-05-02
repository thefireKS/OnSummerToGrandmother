using UnityEngine;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits;

    [SerializeField] private float timeBetweenSpawn;
    private float _timer;

    [SerializeField] private float percentageToSaveZone;
    private Camera _mainCamera;

    [SerializeField] private float spawnForce;
    [SerializeField] private float angleToSpawn;

    private void Start()
    {
        _mainCamera = Camera.main;

        percentageToSaveZone /= 100f;
        
        _timer += timeBetweenSpawn;
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= timeBetweenSpawn)
        {
            _timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 screen = new Vector3(_mainCamera.pixelWidth, _mainCamera.pixelHeight, 0);

        var maxWidth = _mainCamera.ScreenToWorldPoint(screen).x;

        var currentY = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        currentY -= 2f;
        
        maxWidth *= 1 - percentageToSaveZone;
        var minWidth = -maxWidth;

        var currentX = Random.Range(minWidth, maxWidth);

        var fruitToSpawn = fruits[Random.Range(0, fruits.Length)];

        Vector3 spawnPosition = new Vector3(currentX, currentY, 0);
        Quaternion angle = Quaternion.Euler(0, 0, Random.Range(-angleToSpawn, angleToSpawn));

        GameObject fruit = Instantiate(fruitToSpawn, spawnPosition, angle);
        Debug.Log(fruit.transform.rotation);
        
        
        fruit.GetComponent<Rigidbody2D>().AddForce(fruit.transform.up * (spawnForce * Random.Range(0.8f,1.5f)),ForceMode2D.Impulse);
    }
}
