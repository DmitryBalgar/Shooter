using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _shootingJoystick;
    [SerializeField] private bool _joystickEnable;

    [Header("Camera")]
    private Camera _camera;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb;

    [Header("Weapons")]
    [SerializeField] private WeaponController _weaponController;

    public bool JoystickEnable => _joystickEnable;

    public event UnityAction onAim;
    public event UnityAction<Vector2> onShoot;
    public event UnityAction stopAim;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        if (!_joystickEnable)
        {
            _movementJoystick.gameObject.SetActive(false);
            _shootingJoystick.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        #region JoystickInput
        if (_joystickEnable)
        {
            _playerMovement.MovementDirection = _movementJoystick.Direction;
            _playerMovement.ShootingDirection = _shootingJoystick.Direction;
            ShootingJoystickInput();
        }
        #endregion

        if (!_joystickEnable)
        {
            _playerMovement.MovementDirection = new Vector2(Input.GetAxis(GlobalConst.HorizontalAxis), Input.GetAxis(GlobalConst.VericalAxis));
            if (Input.GetMouseButton(GlobalConst.RMB))
            {
                onAim?.Invoke();
                Vector2 dir = _camera.ScreenToWorldPoint(Input.mousePosition) - new Vector3(_rb.position.x,_rb.position.y,0);
                _playerMovement.ShootingDirection = dir.normalized;
                if (Input.GetMouseButton(GlobalConst.LMB))
                {
                    onShoot?.Invoke(dir.normalized);
                }
            }
            if (Input.GetMouseButtonUp(GlobalConst.RMB))
            {
                stopAim?.Invoke();
                _playerMovement.ShootingDirection = Vector3.zero;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _weaponController.WeaponSwapLeft();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _weaponController.WeaponSwapRight();
            }

        }
    }

    private void ShootingJoystickInput()
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
