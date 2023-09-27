public class TakenDamageParticle : ParticleListener
{
    public override void Initialize()
    {
        if (TryGetComponent(out Bullet bullet))
        {
            SetEvent(bullet.OnHit);
        }
    }
}
