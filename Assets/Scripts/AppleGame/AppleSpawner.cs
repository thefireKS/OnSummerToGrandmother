using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleSpawner : MonoBehaviour
{
    [Serializable] private struct Apple
    {
        [SerializeField] public GameObject apple;
        [SerializeField] public int count;
    }
    
    [SerializeField] private float minSpawnPosition, maxSpawnPosition, heightSpawnPosition;

    [SerializeField] private Apple[] applesSetup;
    private GameObject[] _apples;

    [SerializeField] private float spawnTimer;
    private float _timer;

    private void OnEnable()
    {
        SetupApples();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if(_timer >= spawnTimer) Spawn();
    }

    private void SetupApples()
    {
        List<GameObject> applesList = new List<GameObject>();
        foreach (var apple in applesSetup)
        {
            for (int appleCount = 0; appleCount < apple.count; appleCount++)
            {
                applesList.Add(apple.apple);
            }
        }
        _apples = applesList.ToArray();
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minSpawnPosition, maxSpawnPosition), heightSpawnPosition, 0);
        GameObject appleToSpawn = _apples[Random.Range(0, _apples.Length)];
        Instantiate(appleToSpawn, spawnPosition, Quaternion.identity);
        _timer = 0;
    }
}
