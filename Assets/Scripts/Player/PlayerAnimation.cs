using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _playerInput.onAim += Aim;
        _playerInput.stopAim += StopAim;
        _playerInput.onShoot += OnShoot;
    }
    private void OnDisable()
    {
        _playerInput.onAim -= Aim;
        _playerInput.stopAim -= StopAim;
        _playerInput.onShoot -= OnShoot;

    }
    private void Update()
    {
        _animator.SetFloat("velocity", _playerMovement.CurrentVelocity.magnitude);
    }

    private void Aim()
    {
        _animator.SetBool("isAim", true);
        _animator.SetInteger("weaponType", ((int)_playerShoot.CurrentWeapon.CurrentWeapontype));
    }
    private void StopAim()
    {
        _animator.SetBool("isAim", false);
        _animator.SetBool("onShoot", false);

    }
    private void OnShoot(Vector2 temp)
    {
        _animator.SetBool("onShoot", true);
    }





}
