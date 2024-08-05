using UnityEngine;

public class Point : MonoBehaviour, IPoint
{  
    public Transform GetTransform()
    {
        return transform;
    }
}
