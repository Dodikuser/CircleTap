using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public IMover PlMover;
    public PointSpawner PointSpawner;

    private List<IPoint> _points = new List<IPoint>();
    private bool _isMove = false;

    private void OnEnable()
    {
       PlMover = GetComponent<IMover>();   
        
       PointSpawner.PointHasAppeared += AddPoint;
       PlMover.EndMove += StartNewTransition; 
    }
    private void OnDisable()
    {
        PointSpawner.PointHasAppeared -= AddPoint;
        PlMover.EndMove -= StartNewTransition;
    }

    public void MoveTo(IPoint point)
    {
        if (_isMove) return;

        _isMove = true;
        Transform pointTransform = point.GetTransform();
        PlMover.StartMove(pointTransform);
        _points.Remove(point);
    }

    public void AddPoint(IPoint point)
    {
        _points.Add(point);
        MoveTo(point);
    }

    public void StartNewTransition()
    {
        _isMove = false;
        if(_points.Count > 0) MoveTo(_points[0]);
    }  
}
