using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _wellnessBar;
    [SerializeField] private Health _wellness;

    private void OnEnable()
    {
        _wellness.Changed += OnWellnessChanged;
    }

    private void OnDisable()
    {
        _wellness.Changed -= OnWellnessChanged;
    }

    private void OnWellnessChanged(float health)
    {
        _wellnessBar.value = health;
    }
}
