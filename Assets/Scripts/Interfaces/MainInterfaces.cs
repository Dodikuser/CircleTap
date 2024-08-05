using System;
using UnityEngine;

public interface IPlayer
{
    public void MoveTo(IPoint point);
    public void AddPoint(IPoint point);
}
public interface IPoint
{
    public Transform GetTransform();
}
public interface IMover
{
    public event Action EndMove;
    public void StartMove(Transform targetTransform);
}
public interface IPointSpawner
{
    public void SpawnPoint(Vector2 position);
}
public interface ITouchable
{
    public void Touch();
}
