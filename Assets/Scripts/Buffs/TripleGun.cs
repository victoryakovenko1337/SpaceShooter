using System.Collections.Generic;
using UnityEngine;

public class TripleGun: Buff, IRemoveable
{
    [SerializeField] private List<Gun> _additionalGunsPrefab;
    private List<Gun> _currentGuns;

    public override void ApplyBuff(Player player)
    {
        _currentGuns = player.AddGuns(_additionalGunsPrefab);
    }

    public void RemoveBuff(Player player)
    {
        player.RemoveGuns(_currentGuns);
    }
}
