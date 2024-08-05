using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour, ITouchable
{
    public event Action <Vector2> OnTouch;

    public void Touch()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        OnTouch?.Invoke(touchPosition);       
    }
}
