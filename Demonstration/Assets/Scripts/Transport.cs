using System;
using UnityEngine;

public enum MoveDirections
{
    Up,
    Down,
    Left,
    Right,
    Forward,
    Back
}

[RequireComponent(typeof(Rigidbody))]
public class Transport : MonoBehaviour {
    public event Action<MoveDirections> MoveDirectionChanged;
    public event Action<float> VelocityChanged;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _maxSpeed = 300f;
    [SerializeField] private float _moveSpeed = 1000f;
    [SerializeField] private BikeAnimator _animator;
    [SerializeField] private Speedometer _speedometer;

    private int _isSpeedUp;
    private float _previousVelocity;

    public int IsSpeedUp => _isSpeedUp;
    
    private void Awake() {
        _rigidbody ??= GetComponent<Rigidbody>();

        _animator.Init(this);
        _speedometer.Init(this);
    }

    public void ForwardMove(int k) {
        if (_rigidbody.velocity.magnitude > _maxSpeed)
            return;

        _rigidbody.AddForce(0, 0, _moveSpeed * k, ForceMode.VelocityChange);

        float currentSpeedPercent = (_rigidbody.velocity.magnitude) / _maxSpeed;
        VelocityChanged?.Invoke(currentSpeedPercent);

        if (k > 0)
            MoveDirectionChanged?.Invoke(MoveDirections.Forward);
        else
            MoveDirectionChanged?.Invoke(MoveDirections.Back);
    }

    public void LeftMove() {
        if (transform.position.x <= -4.9)
            return;

        MoveDirectionChanged?.Invoke(MoveDirections.Left);
    }

    public void RightMove() {
        if (transform.position.x >= 4.5)
            return;

        MoveDirectionChanged?.Invoke(MoveDirections.Right);
    }

    private void FixedUpdate() {
        float currentVelocity = _rigidbody.velocity.magnitude;
        float velocityDelta = currentVelocity - _previousVelocity;
        //Debug.Log($"VelocityDelta: {velocityDelta}");

        _isSpeedUp = velocityDelta > 0 ? -1 : 1;
        _previousVelocity = currentVelocity;
    }
}
