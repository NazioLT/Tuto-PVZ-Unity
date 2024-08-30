using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _health = 100;
    private bool _dead = false;

    private UnityEvent _onDie = new();

    public void Damage(int amount)
    {
        if (_dead)
            return;

        _health = Mathf.Max(_health - amount, 0);

        if (_health == 0)
        {
            Die();
        }
    }

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Die()
    {
        _dead = true;
        _onDie.Invoke();
        Destroy(gameObject);
    }
}
