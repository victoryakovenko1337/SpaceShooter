using UnityEngine;

public class Heal : Buff
{
    [SerializeField][Range(5, 20)] private int _hpGain; 

    public override void ApplyBuff(Player player)
    {
        if (_hpGain < 0) return;
        
        player.ChangeHealth(_hpGain);
    }
}
