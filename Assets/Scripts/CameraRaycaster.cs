using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _mask = 0;
    private Camera _cam = null;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Start()
    {
        InputReader.Instance.OnFirePerformed.AddListener(OnFirePerformed);
    }

    private void OnFirePerformed()
    {
        Vector2 mousePosition = InputReader.Instance.MousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, 100f, _mask))
            return;

        if (!hit.collider.TryGetComponent(out Grid grid))
            return;

        Vector2Int square = new Vector2Int(
                (int)hit.point.x,
                (int)hit.point.z
            );

        grid.Select(square);
    }
}
