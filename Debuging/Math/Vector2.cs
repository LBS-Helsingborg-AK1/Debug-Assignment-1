using System;

struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x = 0, float y = 0)
    {
        this.x = x;
        this.y = y;
    }

    void Normalize()
    {
        float l = length;
        x = x / l;
        y = y / l;
    }

    Vector2 normalized
    {
        get
        {
            float l = length;
            return new Vector2(x / l, y / l);
        }
    }

    public float length { get => MathF.Sqrt(x * x + y * y); }
    public float lengthSquared { get => x * x + y * y; }

    public static Vector2 operator *(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x * right.x, left.y * right.y);
    }

    public static Vector2 operator /(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x / right.x, left.y / right.y);
    }

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x + right.x, left.y + right.y);
    }

    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x - right.x, left.y - right.y);
    }

    public void SetConsole()
    {
        Console.SetCursorPosition(Convert.ToInt32(MathF.Floor(x)), Convert.ToInt32(MathF.Floor(y)));
    }
}
