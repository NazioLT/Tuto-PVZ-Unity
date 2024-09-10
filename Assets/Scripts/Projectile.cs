using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private int _damages = 1;
    [SerializeField] private LayerMask _mask;

    private Rigidbody _rigidbody;

    public void Launch(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _mask);

        foreach (Collider col in colliders)
        {
            if (!col.TryGetComponent(out Life life))
                continue;

            life.Damage(_damages);
            Destroy(gameObject);
            return;
        }
    }
}
