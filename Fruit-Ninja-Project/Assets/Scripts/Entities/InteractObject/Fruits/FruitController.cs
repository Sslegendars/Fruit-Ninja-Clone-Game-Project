using UnityEngine;

public class FruitController : InteractObjectController
{   
    private GameObject wholeFruit;
    private GameObject slicedFruit;
    private FruitMovement fruitMovement;
    private Collider fruitCollider;
    private GameObject fruitJuice;        
    private bool isFruitSliced = false;    
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement, GameObject fruitJuice, GameObject wholeFruit, GameObject slicedFruit)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
        this.fruitJuice = fruitJuice;
        this.wholeFruit = wholeFruit;
        this.slicedFruit = slicedFruit;
    }
    private void Start()
    {
        InitializeComponents();
        DestroyGameObjectDepentOnTime();
    }
    private void Update()
    {
        FruitMovementWhenGameIsPlay();
        DestroyFruitWhenGameIsOver();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            HandleBladeCollision(other);
        }
        
    }
    protected virtual void InitializeComponents()
    {
        MakeFruitDynamicRigidbody();
        FruitMovementWhenGameIsStart();
        ActivateWholeFruit();
        DeactivateSlicedFruit();
        DeactivateFruitJuice();
        EnableFruitCollider();
    }
    private void HandleBladeCollision(Collider bladeCollider)
    {       
        Blade blade = bladeCollider.GetComponent<Blade>();       
        Slice(blade.direction, blade.transform.position, blade.sliceForce);
        GameManager.Instance.FruitWasCut(blade.PlayerID);
        PlayFruitCutSound();
        isFruitSliced = true;
    }    
    
    public void Slice(Vector3 direction, Vector3 position, float force)
    {        
        isFruitSliced = true;
        DeactivateWholeFruit();
        ActivateSlicedFruit();
        ActivateFruitJuice();
        MakeFruitKinematicRigidbody();
        DisableFruitCollider();
        RotateObjectAccordingCuttingAngle(direction);
        ApplyForceToSlices(direction, position, force);       
    }
    private Quaternion RotateObjectAccordingCuttingAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;
        Vector3 currentRotation = slicedFruit.transform.rotation.eulerAngles;
        slicedFruit.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);      
        return slicedFruit.transform.rotation;        
    }
    private void ApplyForceToSlices(Vector3 direction, Vector3 position, float force)
    {
        Rigidbody[] slices = slicedFruit.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitMovement.interactObjectRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
    private void FruitMovementWhenGameIsStart()
    {
        fruitMovement.InteractObjectApplyForce();
    }
    private void FruitMovementWhenGameIsPlay()
    {
        if (!isFruitSliced)
        {
            fruitMovement.InteractObjectRotate();
        }
    }
    protected void DestroyFruitWhenGameIsOver()
    {
        if (GameManager.Instance.GameIsOver == true)
        {
            StopFruitCutSound();
            Destroy(gameObject);
        }
    }
    private void DeactivateWholeFruit()
    {
        wholeFruit.SetActive(false);
    }
    private void ActivateWholeFruit()
    {
        wholeFruit.SetActive(true);
    }
    private void ActivateSlicedFruit()
    {
        slicedFruit.SetActive(true);
    }
    private void DeactivateSlicedFruit()
    {
        slicedFruit.SetActive(false);
    }
    private void ActivateFruitJuice()
    {
        fruitJuice.SetActive(true);
    }
    private void DeactivateFruitJuice()
    {
        fruitJuice.SetActive(false);
    }
    private void EnableFruitCollider()
    {
        fruitCollider.enabled = true;
    }
    private void DisableFruitCollider()
    {
        fruitCollider.enabled = false;
    }
    private void MakeFruitKinematicRigidbody()
    {
        fruitMovement.interactObjectRigidbody.isKinematic = true;
    }
    private void MakeFruitDynamicRigidbody()
    {
        fruitMovement.interactObjectRigidbody.isKinematic = false;
    }    
    private void PlayFruitCutSound()
    {
        AudioManager.Instance.Play(SoundName.FruitCutSound);
    }
    private void StopFruitCutSound()
    {
        AudioManager.Instance.Stop(SoundName.FruitCutSound);
    }

}
