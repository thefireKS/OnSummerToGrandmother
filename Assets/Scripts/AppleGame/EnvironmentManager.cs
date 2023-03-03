using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private float percentageToSaveZone;
    private float minSpawnPosition, maxSpawnPosition;

    [SerializeField] private GameObject[] borders;

    private void Start()
    {
        percentageToSaveZone /= 100f;
        Vector3 WidthHeight = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0);
        var maxWidth = Camera.main.ScreenToWorldPoint(WidthHeight).x;
        var minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;

        minSpawnPosition = minWidth - maxWidth * percentageToSaveZone;
        maxSpawnPosition = maxWidth * (1 + percentageToSaveZone);

        borders[0].transform.position = new Vector3(minSpawnPosition, 0, 0);
        borders[1].transform.position = new Vector3(maxSpawnPosition, 0, 0);
    }
}
