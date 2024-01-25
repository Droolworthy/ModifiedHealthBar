using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _wellness;
    [SerializeField] private int _wellnessTextBar;

    private int _amountOfWellness = 100;

    public event UnityAction<float> Changed;
    public event UnityAction<int> Modified; 

    public void Heal()
    {
        int maximumHealth = 100;

        float targetValue = ChangeWellness(_wellness);

        Changed?.Invoke(targetValue);

        if (_amountOfWellness < maximumHealth)
        {
            int targetIndicator = _amountOfWellness += _wellnessTextBar;

            Modified?.Invoke(targetIndicator);
        }
    }

    public void Damage()
    {
        int minimumHealth = 0;

        float targetValue = ChangeWellness(-_wellness);

        Changed?.Invoke(targetValue);

        if (_amountOfWellness > minimumHealth)
        {
            int targetIndicator = _amountOfWellness -= _wellnessTextBar;

            Modified?.Invoke(targetIndicator);
        }
    }

    private float ChangeWellness(float health)
    {
        float targetValue = _healthBar.value + health;

        return targetValue;
    }
}
