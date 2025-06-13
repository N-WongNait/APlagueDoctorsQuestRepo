using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Handles the enemies' health, including taking damage, healing, and updating the health bar.
/// </summary>

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP = 30f;
    [SerializeField] private float _currentHP;

    [SerializeField] private Image _healthBar;

    private void Start()
    {
        _currentHP = _maxHP;
    }


    public void ApplyDamage(float value)
    {
        _currentHP -= value;
        UpdateHealthBar();

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            QuestEvents.Update.Invoke(transform.position.x, transform.position.y, transform.position.z);
            gameObject.SetActive(false);
        }
    }

    public void Heal(float value)
    {
        _currentHP += value;
        UpdateHealthBar();

        if (_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }
    }

    void UpdateHealthBar()
    {
        _healthBar.transform.localScale = new Vector3(_currentHP / _maxHP , 1, 1);
    }
}
