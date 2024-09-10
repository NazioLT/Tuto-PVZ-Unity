using UnityEngine;
/// <summary>
/// Script général de la plante, gère les intéractions principales de la plante.
/// </summary>
public class Plant : Character
{
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private float _attackDistance = 6f;
    [SerializeField] private Projectile _projectile = null;
    [SerializeField] private LayerMask _zombieMask;

    private float _currentAttackCooldown = 0f;
    private bool _canAttack = false;

    private Vector2Int _position;

    public void Place(Vector2Int position)
    {
        _position = position;
        transform.position = Utils.GridToWorldSpace(position);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _canAttack = Physics.Raycast(transform.position + Vector3.up, Vector3.right, _attackDistance, _zombieMask);
    }

    private void Update()
    {
        _currentAttackCooldown -= Time.deltaTime;

        if (_currentAttackCooldown < 0 && _canAttack)
            Attack();
    }

    private void Attack()
    {
        if (_currentAttackCooldown > 0f)
            return;

        _currentAttackCooldown = _attackCooldown;

        Projectile proj = Instantiate(_projectile, transform.position + Vector3.up, Quaternion.identity);
        proj.Launch(Vector3.right);
    }
}
