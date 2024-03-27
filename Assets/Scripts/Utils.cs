using UnityEngine;

public static class Utils
{
    public static Vector3 GridToWorldSpace(Vector2Int square)
    {
        return new Vector3(
                square.x + 0.5f,
                0f,
                square.y + 0.5f
            );
    }

    public static Vector3 GetRandomZombiePosition()
    {
        return GridToWorldSpace(new Vector2Int(
            Grid.COLUMN_COUNT + 1,
            Random.Range(0, Grid.LINE_COUNT)));
    }
}
