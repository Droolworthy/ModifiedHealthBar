using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _wellnessIndicator;
    [SerializeField] private float _wellness;

    public event UnityAction<float> Changed;

    public void Heal()
    {
        float targetValue = ChangeWellness(_wellness);

        Changed?.Invoke(targetValue);
    }

    public void Damage()
    {
        float targetValue = ChangeWellness(-_wellness);

        Changed?.Invoke(targetValue);
    }

    private float ChangeWellness(float health)
    {
        float targetValue = _wellnessIndicator.value + health;

        return targetValue;
    }
}
