using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _wellnessBar;
    [SerializeField] private Health _wellness;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

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
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TransformWellnessLevel(health));
    }

    private IEnumerator TransformWellnessLevel(float targetValue)
    {
        bool isWork = true;

        while (isWork)
        {
            _wellnessBar.value = Mathf.MoveTowards(_wellnessBar.value, targetValue, Time.deltaTime * _speed);

            if (_wellnessBar.value == targetValue)
            {
                isWork = false;

                StopCoroutine(_coroutine);
            }

            yield return null;
        }
    }
}
