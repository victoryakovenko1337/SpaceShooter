using UnityEngine;

public class StandaloneInputService : InputService
{
    public override Vector2 Axis => SimpleInputAxis();
}
