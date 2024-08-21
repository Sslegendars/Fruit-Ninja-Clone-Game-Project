using UnityEngine;

public class FruitController : InteractObjectController
{   
    public GameObject whole;
    public GameObject sliced;
    private FruitMovement fruitMovement;
    private Collider fruitCollider;
<<<<<<< Updated upstream:Fruit-Ninja-Project/Assets/Scripts/Entities/Fruits/FruitController.cs
    private GameObject fruitJuice;    
    private const float maxLifeTime = 5f;
    private bool isFruitSliced = false;
=======
    private GameObject fruitJuice;
    private bool isFruitSliced = false;  
>>>>>>> Stashed changes:Fruit-Ninja-Project/Assets/Scripts/Entities/InteractObject/Fruits/FruitController.cs
    
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement, GameObject fruitJuice)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
        this.fruitJuice = fruitJuice;
    }
    private void Start()
    {
<<<<<<< Updated upstream:Fruit-Ninja-Project/Assets/Scripts/Entities/Fruits/FruitController.cs
        InitializeComponents(); 
    }
    private void Update()
    {
        FruitMovementWhenGameIsPlay();    
        DestroyFruitObjectWhenGameIsOver();
    }
=======
        MakeFruitDynamicRigidbody();
        ActiveWholeFruit();
        DeactiveSlicedFruit();
        DeactiveFruitJuice();
        EnableFruitCollider();
        DestroyGameObjectDepentOnTime();        
    }
    private void Update()
    {
        DestroyGameObjectWhenGameIsOver();
        FruitMovementBehaviour();        
    } 
>>>>>>> Stashed changes:Fruit-Ninja-Project/Assets/Scripts/Entities/InteractObject/Fruits/FruitController.cs
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom Bound"))
        {
            HandleBottomBoundCollision();
        }
    }
    private void FruitMovementBehaviour()
    {   
        if(isFruitSliced == false)
        {
<<<<<<< Updated upstream:Fruit-Ninja-Project/Assets/Scripts/Entities/Fruits/FruitController.cs
            Destroy(gameObject);
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
        DestroFruitDepentOnTime();
    }   
    private void HandleBladeCollision(Collider bladeCollider)
    {       
        Blade blade = bladeCollider.GetComponent<Blade>();       
        Slice(blade.direction, blade.transform.position, blade.sliceForce);
        GameManager.Instance.UpdateScore(1);
        isFruitSliced = true;
    }
=======
            fruitMovement.InteractObjectMovement();
        }       
    }   
   
>>>>>>> Stashed changes:Fruit-Ninja-Project/Assets/Scripts/Entities/InteractObject/Fruits/FruitController.cs
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
<<<<<<< Updated upstream:Fruit-Ninja-Project/Assets/Scripts/Entities/Fruits/FruitController.cs
        float angle = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;
        Vector3 currentRotation = sliced.transform.rotation.eulerAngles;
        sliced.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);
        
=======
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(sliced.transform.rotation.x, sliced.transform.rotation.y, sliced.transform.rotation.z * angle);        
>>>>>>> Stashed changes:Fruit-Ninja-Project/Assets/Scripts/Entities/InteractObject/Fruits/FruitController.cs
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
        fruitMovement.FruitApplyForce();
    }
    private void FruitMovementWhenGameIsPlay()
    {
        if (!isFruitSliced)
        {
            fruitMovement.FruitRotate();
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
