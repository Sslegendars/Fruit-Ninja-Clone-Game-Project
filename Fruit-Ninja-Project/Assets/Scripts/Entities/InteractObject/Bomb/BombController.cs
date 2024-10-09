using UnityEngine;

public class BombController : InteractObjectController
{
    private Collider bombCollider;
    private BombMovement bombMovement;
    private ParticleSystem bombExplosionParticle;

    private const float inactiveDelay = 0.85f;
    
    private bool isBombSliced = false;
    
    public void Initialize(Collider bombCollider, BombMovement bombMovement,ParticleSystem bombExplosionParticle)
    {
        this.bombCollider = bombCollider;
        this.bombMovement = bombMovement;
        this.bombExplosionParticle = bombExplosionParticle;        
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(InitializeBombAfterDelay());
    }
    private System.Collections.IEnumerator InitializeBombAfterDelay()
    {
        yield return null;
        InitializeBombComponents();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (isBombSliced)
        {
            isBombSliced = false;
        }
        

    }
    private void Update()
    {
        DeactivateBombWhenBombIsSliced();
        CheckBombMovementWhenGameIsPlay();
        DeactivateBombWhenGameIsOver();
    }   
    private void InitializeBombComponents()
    {
        StopExplosionParticle();
        PlayBombFuseSound();        
        EnabledBombCollider();
        MakeBombDynamicRigidbody();
        BombMovementWhenGameIsStart();
    }
    protected override void HandleBladeCollision(Collider bladecollider)
    {
        PlayerLives playerlives = bladecollider.GetComponentInParent<PlayerLives>();
        playerlives.Zerolives();
        isBombSliced = true;
        MakeBombKinematicRigidbody();
        DisabledBombCollider();
        PlayExplosionPaticle();
        StopBombFuseSound();
        PlayBombExplosionSound();
        GameManager.Instance.GameOver();
    }
    private void DeactivateBombDelay()
    {
        Invoke("DeactivateBomb", inactiveDelay);
    }
    private void DeactivateBomb()
    {
        gameObject.SetActive(false);
    }
    private void PlayExplosionPaticle()
    {
        bombExplosionParticle.Play();
    }
    private void StopExplosionParticle()
    {
        bombExplosionParticle.Stop();
    }
    private void MakeBombKinematicRigidbody()
    {
        bombMovement.interactObjectRigidbody.isKinematic = true; 
    }
    private void MakeBombDynamicRigidbody()
    {
        bombMovement.interactObjectRigidbody.isKinematic = false;
    }
    private void DeactivateBombWhenGameIsOver()
    {
        if (GameManager.Instance.GameIsOver && !isBombSliced)
        {
            StopBombFuseSound();
            StopAllCoroutines();
            DeactivateBomb();
        }        
    }
    
    private void DeactivateBombWhenBombIsSliced()
    {
        if (isBombSliced)
        {
            DeactivateBombDelay();
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
    private void PlayBombFuseSound()
    {
        AudioManager.Instance.Play(SoundName.BombFuseSound);
    }
    private void StopBombFuseSound()
    {
        AudioManager.Instance.Stop(SoundName.BombFuseSound);
    }
    private void PlayBombExplosionSound()
    {
        AudioManager.Instance.Play(SoundName.BombExplosionSound);
    }
   

}
