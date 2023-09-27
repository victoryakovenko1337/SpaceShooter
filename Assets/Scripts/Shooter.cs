using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns;
    private Unit owner;

    private void Awake() 
    {
        owner = GetComponent<Unit>();

        foreach(var gun in _guns)
        {
            gun.SetOwner(owner);
        }
    }

    public void AddGun(Gun gun)
    {
        gun.SetOwner(owner);
        _guns.Add(gun);
    }

    public void RemoveGun(Gun gun)
    {
        _guns.Remove(gun);
    }
}
