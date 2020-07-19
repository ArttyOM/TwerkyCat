using UnityEngine;
using System.Collections;

public static class InputMovementUtility
{
    public static Vector2 getMousePositionOffet(Vector2 inputData, Transform target)
    {
        Vector2 targetPosition = target.position;
        return (inputData - targetPosition);
    }
}
