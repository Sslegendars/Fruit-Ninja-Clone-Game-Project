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
    }
    private void Update()
    {
        CheckAndDestroyBomb();
        CheckBombMovementWhenGameIsPlay();
        DestroyBombWhenGameIsOver();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            PlayerLives playerlives = other.GetComponentInParent<PlayerLives>();
            playerlives.Zerolives();
            HandleBladeCollision();         

        }
    }
    private void HandleBladeCollision()
    {
        isBombSliced = true;        
        bombMovement.ObjectRigidbodyIsKinematic();
        DisabledBombCollider();
        bombExplosionParticle.Play();
        GameManager.Instance.GameOver();
    }
    private void DestroyBombWhenBombIsSliced()
    {
        Destroy(gameObject, 0.85f);
    }
    private void DestroyBombWhenGameIsOver()
    {
        if (GameManager.Instance.GameIsOver && !isBombSliced)
        {
            Destroy(gameObject);
        }        
    }
    
    private void CheckAndDestroyBomb()
    {
        if (isBombSliced)
        {
            DestroyBombWhenBombIsSliced();
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
