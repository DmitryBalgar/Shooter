using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _shootingJoystick;
    private PlayerMovement _playerMovement;

    public event UnityAction onAim;
    public event UnityAction<Vector2> onShoot;

    public event UnityAction stopAim;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        _playerMovement.MovementDirection = _movementJoystick.Direction;
        _playerMovement.ShootingDirection = _shootingJoystick.Direction;
        ShootingInput();

    }

    private void ShootingInput()
    {
        if (_shootingJoystick.Direction.magnitude > 0)
        {
            onAim?.Invoke();
            if (Mathf.Clamp01(_shootingJoystick.Direction.magnitude) == 1)
            {
                onShoot?.Invoke(_shootingJoystick.Direction.normalized);
            }
        }
        else
            stopAim?.Invoke();

    }

}
