using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _wellnessIndicator;
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
        _wellnessIndicator.value = health;
    }
}
