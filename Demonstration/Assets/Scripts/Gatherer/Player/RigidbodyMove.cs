using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMove : MonoBehaviour {
    public event Action<MoveStatus> MoveStatusChanged;
    public event Action<float> MoveSpeedChanged;

    private PlayerConfig _config;
    private DynamicJoystick _joystick;
    
    private Rigidbody _rigidbody;
    private Vector2 _moveInput;

    public MoveStatus CurrentMoveStatus { get; private set; }
    public bool IsActive { get; private set; } = false;
    private float _speed => _config.MoveSpeed;


    private void Awake() {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    public void Init(PlayerConfig config, DynamicJoystick joystick) {
        _config = config;
        _joystick = joystick;

        CurrentMoveStatus = MoveStatus.Stop;

        MoveStatusChanged?.Invoke(CurrentMoveStatus);
        MoveSpeedChanged?.Invoke(_rigidbody.velocity.magnitude);

        IsActive = true;
    }

    private void FixedUpdate() {
        if (IsActive == false)
            return;

        _moveInput = _joystick.Direction;

        if (_moveInput != Vector2.zero) {
            _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed;
            
            if (_rigidbody.velocity != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);

            CurrentMoveStatus = MoveStatus.Active;
            
        }
        else {
            _rigidbody.velocity = Vector3.zero;
            CurrentMoveStatus = MoveStatus.Stop;
        }

        
        MoveStatusChanged?.Invoke(CurrentMoveStatus);
        MoveSpeedChanged?.Invoke(_rigidbody.velocity.magnitude);

        //Debug.Log($"Velocity: {_rigidbody.velocity.magnitude}");
    }
}

