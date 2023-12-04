using UnityEngine;

[RequireComponent(typeof(Player))]
public class HeroMove : MonoBehaviour
{
    private IInputService _inputService;
    private Bounds _bounds;
    private Player _player;

    private void Awake()
    {
        _inputService = AllServices.Container.Single<IInputService>();
        _bounds = AllServices.Container.Single<Bounds>();

        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Vector2 movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);

        _player.transform.position = _bounds.CalculateBounds(_player.transform.position, movementVector * _player.MoveSpeed * Time.deltaTime);
    }
}
