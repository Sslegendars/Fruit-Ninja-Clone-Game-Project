using UnityEngine;
public class BombInitializer : InteractObjectInitializer
{   
    [SerializeField]
    private ParticleSystem bombExplosionParticle; 
    protected BombController bombController;
    protected BombMovement bombMovement;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        bombMovement = (BombMovement)interactObjectMovement;
        bombController = (BombController)interactObjectController;
        bombController.Initialize(_collider,bombMovement,bombExplosionParticle);
    }
}
