using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    private static InputReader _instance = null;

    private UnityEvent _onFirePerformed = new();
    private Mouse _mouse;
    private Vector2 _mousePosition = Vector2.zero;

    public static InputReader Instance => _instance;

    public UnityEvent OnFirePerformed => _onFirePerformed;
    public Vector3 MousePosition => _mousePosition;

    private void Awake()
    {
        _instance = this;
        _mouse = Mouse.current;
    }

    private void Update()
    {
        _mousePosition = _mouse.position.ReadValue();
    }

    public void FirePerformed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            _onFirePerformed.Invoke();
    }
}
