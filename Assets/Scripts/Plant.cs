using UnityEngine;
/// <summary>
/// Script général de la plante, gère les intéractions principales de la plante.
/// </summary>
public class Plant : MonoBehaviour
{
    private Vector2Int _square;

    public void Place(Vector2Int square)
    {
        _square = square;
        transform.position = Grid.GridToWorldSpace(square);
    }
}
