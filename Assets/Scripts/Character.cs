using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private Animator _animator = null;

    protected Animator Animator => _animator;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
