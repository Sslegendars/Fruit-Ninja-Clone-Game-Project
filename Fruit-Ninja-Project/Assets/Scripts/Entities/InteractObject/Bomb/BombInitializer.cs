using UnityEngine;
public class BombInitializer : InteractObjectInitializer<BombMovement, BombController>
{
    [SerializeField]
    private ParticleSystem bombExplosionParticle;

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        interactObjectController.Initialize(_collider, interactObjectMovement, bombExplosionParticle);
    }
}
