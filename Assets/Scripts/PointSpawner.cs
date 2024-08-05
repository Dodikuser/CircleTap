using System;
using UnityEngine;

public class PointSpawner : MonoBehaviour, IPointSpawner
{
    [SerializeField] private GameObject PointPrefab;
    [SerializeField] private TouchHandler TouchHandler;

    public event Action<IPoint> PointHasAppeared;

    private void OnEnable()
    {
        TouchHandler.OnTouch += SpawnPoint;
    }
    private void OnDisable()
    {      
        TouchHandler.OnTouch -= SpawnPoint;
    }

    public void SpawnPoint(Vector2 position)
    {
        GameObject point =  Instantiate(PointPrefab, position, Quaternion.identity);
        PointHasAppeared?.Invoke(point.GetComponent<IPoint>());
    }
}
