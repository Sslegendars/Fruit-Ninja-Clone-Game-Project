using UnityEngine;
public class BombInitializer : InteractObjectInitializer
{
    public ParticleSystem bombExplosionParticle; 
    protected BombController bombController;
    protected BombMovement bombMovement;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        bombMovement = (BombMovement)_movement;
        bombController = (BombController)interactObjectController;
        bombController.Initialize(_collider,bombMovement,bombExplosionParticle,interactObjectRigidbody);
    }
}
