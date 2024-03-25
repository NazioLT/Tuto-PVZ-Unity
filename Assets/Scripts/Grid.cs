using UnityEngine;

/// <summary>
/// Script qui place et retire les plantes de la grille.
/// </summary>
public class Grid : MonoBehaviour
{
    private Plant[,] _squares = new Plant[COLUMN_COUNT, LINE_COUNT];

    public const int COLUMN_COUNT = 9;
    public const int LINE_COUNT = 5;

    public void Select(Vector2Int position)
    {
        Plant plantToPlace = Deck.Instance.GetPlantToPlace();

        if (plantToPlace == null)
            return;

        Plant plantAtPos = GetPlant(position);

        if (plantAtPos == null)
            PlacePlant(plantToPlace, position);
    }

    private Plant GetPlant(Vector2Int position)
    {
        return _squares[position.x, position.y];
    }

    private void PlacePlant(Plant plantPrefab, Vector2Int position)
    {
        Plant plant = Instantiate(plantPrefab);
        plant.Place(position);

        _squares[position.x, position.y] = plant;
    }
}