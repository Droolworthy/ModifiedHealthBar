using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _wellnessIndicator;
    [SerializeField] private Health _wellness;

    private void OnEnable()
    {
        _wellness.Modified += OnWellnessChanged;
    }

    private void OnDisable()
    {
        _wellness.Modified -= OnWellnessChanged;
    }

    private void OnWellnessChanged(int health)
    {
        _wellnessIndicator.text = health.ToString() + "/100";
    }
}
