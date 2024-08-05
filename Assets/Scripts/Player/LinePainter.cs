using System.Collections.Generic;
using UnityEngine;

public class LinePainter : MonoBehaviour
{
    [SerializeField] private LineRenderer Line;
    [SerializeField] private GameObject Player;
    private List<Vector3> _targetPoints = new List<Vector3>() { new Vector3(0,0,0) };

    public PointSpawner PointSpawner;
    public Player PlayerScript;

    private void OnEnable()
    {
        PointSpawner.PointHasAppeared += AddPoint;
    }
    private void OnDisable()
    {
        PointSpawner.PointHasAppeared -= AddPoint;
        PlayerScript.PlMover.EndMove -= RemovePoint;
    }

    private void Start()
    {
        PlayerScript.PlMover.EndMove += RemovePoint;
    }

    private void LateUpdate()
    {
        Line.SetPosition(0, Player.transform.position);
    }

    private void AddPoint(IPoint point)
    {
        Line.positionCount++;
        _targetPoints.Add(point.GetTransform().position);
        Line.SetPositions(_targetPoints.ToArray());
    }
    private void RemovePoint()
    {
        Line.positionCount--;
        _targetPoints.Remove(_targetPoints[1]);
        Line.SetPositions(_targetPoints.ToArray());
    }
}
