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

    [SerializeField] private float percentageToSaveZone;
    private float minSpawnPosition, maxSpawnPosition, heightSpawnPosition;

    [SerializeField] private Apple[] applesSetup;
    private GameObject[] _apples;

    [SerializeField] private float spawnTimer;
    private float _timer;
    private bool _stop;

    private void OnEnable()
    {
        ScoreManager.win += Stop;
        
        percentageToSaveZone /= 100f;
        SetupApples();
        if (Camera.main != null)
        {
            var mainCamera = Camera.main;
            Vector3 widthHeight = new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0);
            var maxWidth = Camera.main.ScreenToWorldPoint(widthHeight).x;
            var minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            var maxHeight = Camera.main.ScreenToWorldPoint(widthHeight).y;
        
            minSpawnPosition = minWidth + maxWidth * percentageToSaveZone;
            maxSpawnPosition = maxWidth * (1 - percentageToSaveZone);
            heightSpawnPosition = maxHeight * (1 + 2 * percentageToSaveZone);
        }
    }

    private void FixedUpdate()
    {
        if(!_stop) _timer += Time.fixedDeltaTime;
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

    private void Stop()
    {
        _stop = true;
    }
}
