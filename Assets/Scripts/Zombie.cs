using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private LayerMask _plantMask = 0;

    [SerializeField] private int _damages = 20;
    [SerializeField] private float _attackCooldown = 0.5f;

    private float _currentAttackCooldown = 0f;
    private bool _canAttack;

    private GameObject _plant = null;
    private Rigidbody _rigidbody = null;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentAttackCooldown -= Time.deltaTime;

        if (_currentAttackCooldown < 0 && _canAttack)
            Attack();
    }

    private void FixedUpdate()
    {
        _canAttack = CanAttack();

        bool moving = _rigidbody.position.x > -0.5f && !_canAttack;

        if (moving)
            _rigidbody.position += _speed * Time.fixedDeltaTime * Vector3.left;
    }

    private void Attack()
    {
        if (_currentAttackCooldown > 0f)
            return;

        _currentAttackCooldown = _attackCooldown;

        Life life = _plant.GetComponent<Life>();
        life.Damage(_damages);
    }

    private bool CanAttack()
    {
        bool canAttack = Physics.Raycast(_rigidbody.position + Vector3.up * 0.5f, Vector3.left, out RaycastHit hit, 1f, _plantMask);

        Animator.SetBool("Attacking", canAttack);

        if (!canAttack)
        {
            _plant = null;
            return false;//
        }

        _plant = hit.transform.gameObject;
        return true;
    }
}
