using UnityEngine;

public class Bounds : IService
{
    private const float PaddingSides = 0.5f;
    private const float PaddingTop = 6f;
    private const float PaddingBottom = 2f;

    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    
    public Bounds()
    {
        InitBounds();
    }

    public float GetPaddingSides() => PaddingSides;
    public float GetPaddingTop() => PaddingTop;
    public float GetPaddingBottom() => PaddingBottom;


    public Vector2 CalculateBounds(Vector2 oldPlayerPosition, Vector2 delta)
    {
        Vector2 newPlayerPosition = new()
        {
            x = Mathf.Clamp(oldPlayerPosition.x + delta.x, _minBounds.x + PaddingSides, _maxBounds.x - PaddingSides),
            y = Mathf.Clamp(oldPlayerPosition.y + delta.y, _minBounds.y + PaddingBottom, _maxBounds.y - PaddingTop)
        };

        return newPlayerPosition;
    }

    private void InitBounds()
    {
        Camera camera = Camera.main; 
        _minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
