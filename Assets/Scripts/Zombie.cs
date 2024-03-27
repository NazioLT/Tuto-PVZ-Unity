using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private LayerMask _plantMask = 0;

    private Rigidbody _rigidbody = null;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bool isPlantForward = Physics.Raycast(_rigidbody.position + Vector3.up * 0.5f, Vector3.left, 1f, _plantMask);

        Animator.SetBool("Attacking", isPlantForward);

        if (_rigidbody.position.x < -0.5f || isPlantForward)
            return;

        _rigidbody.position += _speed * Time.fixedDeltaTime * Vector3.left;
    }
}
