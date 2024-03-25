using UnityEngine;

/// <summary>
/// Script qui place et retire les plantes de la grille.
/// </summary>
public class Grid : MonoBehaviour
{
    [SerializeField] private Plant _plant = null;

    public static Vector3 GridToWorldSpace(Vector2 square)
    {
        return new Vector3(
                square.x + 0.5f,
                0f,
                square.y + 0.5f
            );
    }

    public void Select(Vector2Int position)
    {
        Debug.Log("position " + position);
        PlacePlant(_plant, position);
    }

    private void PlacePlant(Plant plantPrefab, Vector2Int position)
    {
        Plant plant = Instantiate(plantPrefab);
        plant.Place(position);
    }
}