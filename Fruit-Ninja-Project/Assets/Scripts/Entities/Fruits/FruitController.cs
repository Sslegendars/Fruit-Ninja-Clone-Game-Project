using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
   
    public GameObject whole;
    public GameObject sliced;
    private FruitMovement fruitMovement;
    private Collider fruitCollider;
    private GameObject fruitJuice;    
    private const float maxLifeTime = 5f;
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement, GameObject fruitJuice)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
        this.fruitJuice = fruitJuice;
    }
    private void Start()
    {
        MakeFruitDynamicRigidbody();
        ActiveWholeFruit();
        DeactiveSlicedFruit();
        DeactiveFruitJuice();
        EnableFruitCollider();
        DestroFruitDepentOnTime();        
    }
    private void Update()
    {
        DestroyFruitObjectWhenGameIsOver();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            HandleBladeCollision(other);
        }
        if (other.CompareTag("Bottom Bound"))
        {
            HandleBottomBoundCollision();
        }
    }
    private void DestroFruitDepentOnTime()
    {
        Destroy(gameObject, maxLifeTime);
    }
    private void DestroyFruitObjectWhenGameIsOver()
    {
        if (GameManager.Instance.gameIsOver == true)
        {
            Destroy(gameObject);
        }
    }
    private void HandleBladeCollision(Collider bladeCollider)
    {
        Blade blade = bladeCollider.GetComponent<Blade>();
       
        Slice(blade.direction, blade.transform.position, blade.sliceForce);
        GameManager.Instance.UpdateScore(1);
    }
    private void HandleBottomBoundCollision()
    {
        PlayerLives playerLives = FindObjectOfType<PlayerLives>();
        playerLives.DecreaseLife();
    }
    private void Slice(Vector3 direction, Vector3 position, float force)
    {
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //**********************************************
        //**********************************************
        //**********************************************
        // WaterMelon and coconut rotation,on different , need to change
        
        sliced.transform.rotation = Quaternion.Euler(0, 0, angle);      
        return sliced.transform.rotation;        
    }
    private void ApplyForceToSlices(Vector3 direction, Vector3 position, float force)
    {
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitMovement.fruitRigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
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
        fruitMovement.fruitRigidBody.isKinematic = true;
    }
    private void MakeFruitDynamicRigidbody()
    {
        fruitMovement.fruitRigidBody.isKinematic = false;
    }    

}
