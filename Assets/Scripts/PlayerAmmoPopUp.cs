using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmmoPopUp : MonoBehaviour
{
    [SerializeField] private GameObject _playerCanvas;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TMP_Text _ammoIncreaseText;
    [SerializeField] private Animator _animator;

    public void ShowIncome(int income, Weapon currentWeapon)
    {
        _animator.enabled = true;
        _playerCanvas.SetActive(true);
        _weaponImage.sprite = currentWeapon.Icon;
        _ammoIncreaseText.text = $"+{income}";
        _animator.Play("Fade");
        Destroy(this.gameObject, 1f);

    }
}
