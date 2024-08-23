using UnityEngine;

public class BombController : InteractObjectController
{
    private Collider bombCollider;
    private BombMovement bombMovement;
    private ParticleSystem bombExplosionParticle;
    
    private bool isBombSliced = false;
    
    public void Initialize(Collider bombCollider, BombMovement bombMovement,ParticleSystem bombExplosionParticle)
    {
        this.bombCollider = bombCollider;
        this.bombMovement = bombMovement;
        this.bombExplosionParticle = bombExplosionParticle;        
    }
    private void Start()
    {
        bombExplosionParticle.Stop();
        DestroyGameObjectDepentOnTime();
        EnabledBombCollider();
        BombMovementWhenGameIsStart();
        // Sound start
    }
    private void Update()
    {
        CheckAndDestroyBomb();
        CheckBombMovementWhenGameIsPlay();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            HandleBladeCollision();         

        }
    }
    private void HandleBladeCollision()
    {
        isBombSliced = true;        
        bombMovement.ObjectRigidbodyIsKinematic();
        DisabledBombCollider();
        bombExplosionParticle.Play();
        // Sound explosion
        // Sound start.Stop()
        GameManager.Instance.GameOver();
    }
    private void DestroyBombWhenGameIsOver()
    {        
        Destroy(gameObject, 1f);
    }
    private void CheckAndDestroyBomb()
    {
        if (isBombSliced)
        {
            DestroyBombWhenGameIsOver();
        }
    }
    private void CheckBombMovementWhenGameIsPlay()
    {
        if (!isBombSliced)
        {
            BombMovementWhenGameIsPlay();
        }
    }
    private void BombMovementWhenGameIsPlay()
    {
        bombMovement.InteractObjectRotate();
    }
    private void BombMovementWhenGameIsStart()
    {
        bombMovement.InteractObjectApplyForce();
    }
    private void DisabledBombCollider()
    {
        bombCollider.enabled = false;
    }
    private void EnabledBombCollider()
    {
        bombCollider.enabled = true;
    }
   

}
