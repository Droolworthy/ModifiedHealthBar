using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TransformWellnessLevel(health));
    }

    private IEnumerator TransformWellnessLevel(float targetValue)
    {
        bool isWork = true;

        while (isWork)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, Time.deltaTime * _speed);

            if (_healthBar.value == targetValue)
            {
                isWork = false;

                StopCoroutine(_coroutine);
            }

            yield return null;
        }
    }
}
