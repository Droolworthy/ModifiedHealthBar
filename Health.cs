using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _wellness;
    [SerializeField] private int _wellnessTextBar;

    private int _amountOfWellness = 100;
    private int _maximumWellness = 100;
    private int _minimumWellness = 0;

    public event UnityAction<float> Changed;
    public event UnityAction<int> Modified; 

    public void Heal()
    {
        float targetValue = ChangeWellness(_wellness);

        Changed?.Invoke(targetValue);

        if (_amountOfWellness < _maximumWellness)
        {
            int targetIndicator = ModifieWellness(_wellnessTextBar);

            Modified?.Invoke(targetIndicator);
        }
    }

    public void Damage()
    {
        float targetValue = ChangeWellness(-_wellness);

        Changed?.Invoke(targetValue);

        if (_amountOfWellness > _minimumWellness)
        {
            int targetIndicator = ModifieWellness(-_wellnessTextBar);

            Modified?.Invoke(targetIndicator);
        }
    }

    private float ChangeWellness(float health)
    {
        float targetValue = _healthBar.value + health;

        return targetValue;
    }

    private int ModifieWellness(int health) 
    { 
        int targetValue = _amountOfWellness += health;

        return targetValue;
    }
}
