using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;

    private Animator _animator;
    private Coroutine _coroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Play());
    }

    private void Assault(Player target)
    {
        _animator.Play("Assault");

        target.ApplyDamage(_damage);
    }

    private IEnumerator Play()
    {
        bool isWork = true;
        
        while (isWork)
        {
            Assault(Target);

            if(Target == null)
                isWork = false;

            yield return null;
        }

        StopCoroutine(_coroutine);
    }
}
