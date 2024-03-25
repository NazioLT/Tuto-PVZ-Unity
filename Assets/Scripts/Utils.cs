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
}
