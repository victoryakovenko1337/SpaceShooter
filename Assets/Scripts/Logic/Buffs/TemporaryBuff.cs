using UnityEngine;

[RequireComponent(typeof(IRemoveable))]
public class TemporaryBuff : Buff
{
    [SerializeField] private float _lifeTime = 3f;
    private IRemoveable _buff;

    private void Start() 
    {
        _buff = GetComponent<IRemoveable>();
    }

    public override void ApplyBuff(Player player)
    {
        BuffTimer _timer = BuffTimer.Instance;
        _timer.SetTargetTime(_lifeTime);
        _timer.OnCompleted += () =>
        {
            _buff.RemoveBuff(player);
        };
    }
}
