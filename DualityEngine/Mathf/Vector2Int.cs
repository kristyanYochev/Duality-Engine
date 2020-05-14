using System;
namespace DualityEngine.Mathf
{
    public class Vector2Int
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static Vector2Int operator +(Vector2Int v1, Vector2Int v2) => new Vector2Int(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector2 operator *(Vector2Int v, float s) => new Vector2(v.X * s, v.Y * s);
        public static Vector2Int operator *(Vector2Int v, int s) => new Vector2Int(v.X * s, v.Y * s);

        public static Vector2 operator +(Vector2Int v1, Vector2 v2) => new Vector2(v1.X + v2.x, v1.Y + v2.y);
    }
}
