public class Collider2D
{
    public Vector2 minValue;
    public Vector2 maxValue;
    public bool solid;
    public Collider2D(Vector2 minValue, Vector2 maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
    public bool Collision(Collider2D other)
    {
        bool overlapX = this.maxValue.X >= other.minValue.X && this.minValue.X <= other.maxValue.X;

        bool overlapY = this.maxValue.Y >= other.minValue.Y && this.minValue.Y <= other.maxValue.Y;

        return overlapX && overlapY;
    }
    public Vector2 Solid(Collider2D[] others)
    {
        Vector2 repulsion = Vector2.Zero;

        foreach (Collider2D other in others)
        {
            if (this.Collision(other))
            {
                float xOverlap = Math.Min(this.maxValue.X - other.minValue.X, other.maxValue.X - this.minValue.X);
                float yOverlap = Math.Min(this.maxValue.Y - other.minValue.Y, other.maxValue.Y - this.minValue.Y);

                if (xOverlap < yOverlap)
                {
                    if (this.minValue.X < other.minValue.X)
                    {
                        repulsion.X -= xOverlap;
                    }
                    else
                    {
                        repulsion.X += xOverlap;
                    }
                }
                else
                {
                    if (this.minValue.Y < other.minValue.Y)
                    {
                        repulsion.Y -= yOverlap;
                    }
                    else
                    {
                        repulsion.Y += yOverlap;
                    }
                }
            }
        }
        if (repulsion != Vector2.Zero)
        {
            repulsion.Normalize();
        }

        return repulsion;
    }
};
