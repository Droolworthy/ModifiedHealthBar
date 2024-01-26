using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    public override void OnWellnessChanged(float health)
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
            _wellnessIndicator.value = Mathf.MoveTowards(_wellnessIndicator.value, targetValue, Time.deltaTime * _speed);

            if (_wellnessIndicator.value == targetValue)
            {
                isWork = false;

                StopCoroutine(_coroutine);
            }

            yield return null;
        }
    }
}
