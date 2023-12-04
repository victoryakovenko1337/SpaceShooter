using UnityEngine;

public class DamageBuff: Buff, IRemoveable
{
    [SerializeField, Range(50, 100)] private int _damageBonus;
    [SerializeField] private Color _rageColor;

    public override void ApplyBuff(Player player)
    {
        player.ChangeDamage(_damageBonus);
        player.GetComponent<SpriteRenderer>().color = _rageColor;
    }

    public void RemoveBuff(Player player)
    {
        player.ChangeDamage(-_damageBonus);        
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
