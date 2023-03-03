using UnityEngine;

public class CurrantSpawner : MonoBehaviour
{
    [SerializeField] private float percentageToSaveZone;
    private float minWidthPosition, maxWidthPosition, minHeightPosition, maxHeightPosition;

    [SerializeField] private GameObject[] currants;
    [SerializeField] private int currantCount;
    
    private void OnEnable()
    {
        percentageToSaveZone /= 100f;
        if (Camera.main != null)
        {
            var mainCamera = Camera.main;
            Vector3 widthHeight = new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0);
            var maxWidth = Camera.main.ScreenToWorldPoint(widthHeight).x;
            var minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            var maxHeight = Camera.main.ScreenToWorldPoint(widthHeight).y;
            var minHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        
            minWidthPosition = minWidth + maxWidth * percentageToSaveZone;
            maxWidthPosition = maxWidth * (1 - percentageToSaveZone);
            minHeightPosition = minHeight + maxHeight * percentageToSaveZone;
            maxHeightPosition = maxHeight * (1 - percentageToSaveZone);
            
            Spawn();
        }
    }
    
    private void Spawn()
    {
        for (int i = 0; i < currantCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minWidthPosition, maxWidthPosition), Random.Range(minHeightPosition, maxHeightPosition), 50);
            GameObject currantToSpawn = currants[Random.Range(0, currants.Length)];
            Instantiate(currantToSpawn, spawnPosition, Quaternion.identity, transform);
        }
    }
}
