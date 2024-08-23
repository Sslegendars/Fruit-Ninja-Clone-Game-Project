using UnityEngine;

public class FruitController : InteractObjectController
{   
    public GameObject whole;
    public GameObject sliced;
    private FruitMovement fruitMovement;
    private Collider fruitCollider;
    private GameObject fruitJuice;    
    
    private bool isFruitSliced = false;

    
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement, GameObject fruitJuice)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
        this.fruitJuice = fruitJuice;
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
        if (other.CompareTag("Bottom Bound"))
        {
            HandleBottomBoundCollision();
        }
        if (other.CompareTag("Blade"))
        {
            HandleBladeCollision(other);
        }
        
    }
    
    protected virtual void InitializeComponents()
    {        
        MakeFruitDynamicRigidbody();
        FruitMovementWhenGameIsStart();
        ActiveWholeFruit();
        DeactiveSlicedFruit();
        DeactiveFruitJuice();
        EnableFruitCollider();        
    }   
    private void HandleBladeCollision(Collider bladeCollider)
    {       
        Blade blade = bladeCollider.GetComponent<Blade>();       
        Slice(blade.direction, blade.transform.position, blade.sliceForce);
        GameManager.Instance.FruitWasCut();
        isFruitSliced = true;
    }      
    

    private void HandleBottomBoundCollision()
    {
        PlayerLives playerLives = FindObjectOfType<PlayerLives>();
        playerLives.DecreaseLife();
    }    
    public void Slice(Vector3 direction, Vector3 position, float force)
    {        
        isFruitSliced = true;
        DeactiveWholeFruit();
        ActiveSlicedFruit();
        ActiveFruitJuice();
        MakeFruitKinematicRigidbody();
        DisableFruitCollider();
        RotateObjectAccordingCuttingAngle(direction);
        ApplyForceToSlices(direction, position, force);       
    }
    private Quaternion RotateObjectAccordingCuttingAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;
        Vector3 currentRotation = sliced.transform.rotation.eulerAngles;
        sliced.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);      
        return sliced.transform.rotation;        
    }
    private void ApplyForceToSlices(Vector3 direction, Vector3 position, float force)
    {
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
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
            Destroy(gameObject);
        }
    }
    private void DeactiveWholeFruit()
    {
        whole.SetActive(false);
    }
    private void ActiveWholeFruit()
    {
        whole.SetActive(true);
    }
    private void ActiveSlicedFruit()
    {
        sliced.SetActive(true);
    }
    private void DeactiveSlicedFruit()
    {
        sliced.SetActive(false);
    }
    private void ActiveFruitJuice()
    {
        fruitJuice.SetActive(true);
    }
    private void DeactiveFruitJuice()
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

}
