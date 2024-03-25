using UnityEngine;
/// <summary>
/// Script général de la plante, gère les intéractions principales de la plante.
/// </summary>
public class Plant : MonoBehaviour
{
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
}
