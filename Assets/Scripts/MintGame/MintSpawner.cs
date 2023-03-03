using UnityEngine;

public class MintSpawner : MonoBehaviour
{
    [SerializeField] private float percentageToSaveZone;
    private float minWidthPosition, maxWidthPosition, HeightPosition;

    [SerializeField] private GameObject[] mints;
    [SerializeField] private int mintCount;
    
    private void OnEnable()
    {
        percentageToSaveZone /= 100f;
        if (Camera.main != null)
        {
            var mainCamera = Camera.main;
            Vector3 widthHeight = new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0);
            var maxWidth = Camera.main.ScreenToWorldPoint(widthHeight).x;
            var minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            var minHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        
            minWidthPosition = minWidth + maxWidth * percentageToSaveZone;
            maxWidthPosition = maxWidth * (1 - percentageToSaveZone);
            HeightPosition = minHeight;
            
            
            Spawn();
        }
    }
    
    private void Spawn()
    {
        for (int i = 0; i < mintCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minWidthPosition, maxWidthPosition), HeightPosition, 0);
            GameObject currantToSpawn = mints[Random.Range(0, mints.Length)];
            Instantiate(currantToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
