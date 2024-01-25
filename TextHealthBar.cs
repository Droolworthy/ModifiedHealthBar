using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthBar;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Modified += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Modified -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthBar.text = health.ToString() + "/100";
    }
}
