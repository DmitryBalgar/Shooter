using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponImageChanger : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponChanger;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _currentAmmo;
    [SerializeField] private TMP_Text _maxAmmo;

    private void OnEnable()
    {
        _weaponChanger.WeaponChanged += ChangeImage;
        _weaponChanger.CurrentAmmoUpdateUI += AmmoCountUpdate;
    }
    private void OnDisable()
    {
        _weaponChanger.WeaponChanged -= ChangeImage;
        _weaponChanger.CurrentAmmoUpdateUI -= AmmoCountUpdate;
    }

    private void ChangeImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    private void AmmoCountUpdate(int current, int max)
    {
        _currentAmmo.text = current.ToString();
        _maxAmmo.text = max.ToString();
    }

}
