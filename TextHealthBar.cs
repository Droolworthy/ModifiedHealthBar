using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _indicator;

    public override void OnWellnessChanged(float health)
    {
        _indicator.text = health.ToString() + "/100";
    }
}
