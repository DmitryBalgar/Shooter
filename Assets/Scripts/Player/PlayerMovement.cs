using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _slowDownSpeed;
    private float _currentMoveSpeed;

    private Rigidbody2D _rb;
    private PlayerInput _playerInput;

    public Vector2 MovementDirection { get; set; }
    public Vector2 ShootingDirection { get; set; }
    public Vector2 CurrentVelocity { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        _playerInput.onAim += SlowDownMoveSpeed;
        _playerInput.stopAim += RecoverMoveSpeed;
    }
    private void OnDisable()
    {
        _playerInput.onAim -= SlowDownMoveSpeed;
        _playerInput.stopAim -= RecoverMoveSpeed;
    }


    private void Start()
    {
        _currentMoveSpeed = _moveSpeed;
    }

    private void SlowDownMoveSpeed()
    {
        _currentMoveSpeed = _slowDownSpeed;
    }
    private void RecoverMoveSpeed()
    {
        _currentMoveSpeed = _moveSpeed;
    }

    private void Update()
    {
        //_rb.velocity = new Vector2(_speedCurve.Evaluate(MovementDirection.x), _speedCurve.Evaluate(MovementDirection.y));
        _rb.velocity = MovementDirection * _currentMoveSpeed;
        _rb.angularVelocity = 0;
        CurrentVelocity = _rb.velocity;

        if (_playerInput.JoystickEnable)
        {
            if (MovementDirection != Vector2.zero && ShootingDirection == Vector2.zero)
            {
                float angle = Mathf.Atan2(MovementDirection.y, MovementDirection.x) * Mathf.Rad2Deg;
                _rb.rotation = angle;
            }
            if (ShootingDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg;
                _rb.rotation = angle;

            }
        }
        else if (!_playerInput.JoystickEnable)
        {
            if (MovementDirection != Vector2.zero && ShootingDirection == Vector2.zero)
            {
                float angle = Mathf.Atan2(MovementDirection.y, MovementDirection.x) * Mathf.Rad2Deg;
                _rb.rotation = angle;
            }
            if (ShootingDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg;
                _rb.rotation = angle;
            }
        }


    }
}
