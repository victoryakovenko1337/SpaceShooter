using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private float _paddingSides = 0.5f;
    [SerializeField] private float _paddingTop = 6f;
    [SerializeField] private float _paddingBottom = 2f;

    public float PaddingSides => _paddingSides;
    public float PaddingTop => _paddingTop;

    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    
    private void Start()
    {
        InitBounds();
    }

    public Vector2 CalculateBounds(Vector2 oldPlayerPosition, Vector3 delta)
    {
        Vector2 newPlayerPosition = new()
        {
            x = Mathf.Clamp(oldPlayerPosition.x + delta.x, _minBounds.x + _paddingSides, _maxBounds.x - _paddingSides),
            y = Mathf.Clamp(oldPlayerPosition.y + delta.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop)
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
