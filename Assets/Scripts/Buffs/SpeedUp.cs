using UnityEngine;

public class SpeedUp : Buff, IRemoveable
{
    [SerializeField][Range(1f, 2.5f)] private float _speedMultiplier;

    public override void ApplyBuff(Player player)
    {
        player.ChangeSpeed(_speedMultiplier);
    }

    public void RemoveBuff(Player player)
    {
        player.ChangeSpeed(1/_speedMultiplier);
    }
}
