using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private Animator _animator = null;
    private Life _life = null;

    protected Animator Animator => _animator;
    protected Life Life => _life;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _life = GetComponent<Life>();
    }
}
