using System;
using UnityEngine.UI;
using UnityEngine;

public class PLMover : MonoBehaviour, IMover
{
    public float Speed = 10f;
    public Slider speedSlider;

    private Transform _targetTransform;
    public event Action EndMove;

    private void OnDestroy()
    {
        speedSlider.onValueChanged.RemoveListener(OnSpeedSliderChanged);
    }
    private void Awake()
    {
        enabled = false;
        speedSlider.onValueChanged.AddListener(OnSpeedSliderChanged);
        speedSlider.value = Speed;   
    }

    private void FixedUpdate()
    {
        if (_targetTransform == null) return;

        Vector2 direction = (_targetTransform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_targetTransform == collision.transform)
        {
            enabled = false;
            _targetTransform = null;
            EndMove.Invoke();

            Destroy(collision.gameObject);
        }
    }

    public void StartMove(Transform targetTransform)
    {
        _targetTransform = targetTransform;
        speedSlider.value = Speed;
        enabled = true;
    }

    void OnSpeedSliderChanged(float value)
    {
        Speed = value;
    }
}
