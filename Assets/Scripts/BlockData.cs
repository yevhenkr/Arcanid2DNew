using UnityEngine;

public struct BlockData
{
    public readonly int healthPointsPoints;
    public readonly Color Color;

    public BlockData(int healthPoints, Color color)
    {
        healthPointsPoints = healthPoints;
        Color = color;
    }
}