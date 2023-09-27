public class ExplosionParticle : ParticleListener
{
    public override void Initialize()
    {
        if (TryGetComponent(out Unit spaceObject))
        {
            SetEvent(spaceObject.OnDieEvent);
        }
    }
}

