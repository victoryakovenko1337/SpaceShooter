using UnityEngine;

public class ShieldBuff : Buff, IRemoveable
{
    [SerializeField] private Shield _shieldPrefab; 

    private Shield _currentShield;

    public override void ApplyBuff(Player player)
    {
        _currentShield = player.AddShield(_shieldPrefab);
    }

    public void RemoveBuff(Player player)
    {
        player.RemoveShield(_currentShield);
    }
}
