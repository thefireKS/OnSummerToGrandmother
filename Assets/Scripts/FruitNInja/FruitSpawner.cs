using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits;

    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float timeToSpeedUp;
    [Space(5)] 
    [SerializeField] private float timeToCutOff;
    private float _spawnTimer,_speedupTimer;

    [Space(5)]
    [SerializeField] private float percentageToSaveZone;
    private Camera _mainCamera;

    [SerializeField] private float spawnForce;
    [SerializeField] private float angleToSpawn;

    private void Start()
    {
        _mainCamera = Camera.main;

        percentageToSaveZone /= 100f;
        
        _spawnTimer += timeBetweenSpawn;
    }

    private void OnEnable()
    {
        FruitNinjaScoreManager.win += StopSpawning;
    }

    private void OnDisable()
    {
        FruitNinjaScoreManager.win -= StopSpawning;
    }

    private void FixedUpdate()
    {
        _spawnTimer += Time.fixedDeltaTime;
        _speedupTimer += Time.fixedDeltaTime;

        if (_speedupTimer > timeToSpeedUp)
        {
            _speedupTimer = 0;
            timeBetweenSpawn -= timeToCutOff;
        }

        if (_spawnTimer >= timeBetweenSpawn)
        {
            _spawnTimer = 0;
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


        fruit.GetComponent<Rigidbody2D>().AddForce(fruit.transform.up * (spawnForce * Random.Range(0.8f,1.5f)),ForceMode2D.Impulse);
    }

    private void StopSpawning()
    {
        Destroy(gameObject);
    }
}
