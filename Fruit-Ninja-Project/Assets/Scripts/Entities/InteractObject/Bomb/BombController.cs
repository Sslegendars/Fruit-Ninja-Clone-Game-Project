using UnityEngine;

public class BombController : InteractObjectController
{
    private Collider bombCollider;
    private BombMovement bombMovement;
    private ParticleSystem bombExplosionParticle;
    private Rigidbody bombRigidbody;
    public void Initialize(Collider bombCollider, BombMovement bombMovement,ParticleSystem bombExplosionParticle, Rigidbody bombRigidbody)
    {
        this.bombCollider = bombCollider;
        this.bombMovement = bombMovement;
        this.bombExplosionParticle = bombExplosionParticle;
        this.bombRigidbody = bombRigidbody;
    }
    private void Start()
    {   
        bombExplosionParticle.Pause();
        DestroyGameObjectDepentOnTime();
        EnabledBombCollider();
    }
    private void Update()
    {
        DestroyGameObjectWhenGameIsOver();
        BombMovementBehaviour();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            PlayerLives playerLives = other.GetComponentInParent<PlayerLives>();
            playerLives.DecreaseLife();
            DisabledBombCollider();
            bombExplosionParticle.Play();
            // Sound play
            // UIManager Deflect
            // GameManager .gameOver            

        }
    }
    private void ApplyForceToBomb(Vector2 direction, Vector3 position, float force)
    {
        
    }
    private void BombMovementBehaviour()
    {
        bombMovement.InteractObjectMovement();
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
