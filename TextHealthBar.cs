using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _wellnessIndicator;
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
        _wellnessIndicator.text = health.ToString() + "/100";
    }
}
