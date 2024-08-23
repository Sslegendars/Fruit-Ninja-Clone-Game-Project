using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectMovement : MonoBehaviour
{
    protected float minForce = 6f;
    protected float maxForce = 7.5f;

    protected float rotationSpeed = 0;
    protected Vector3 interactObjectRotationDirection;

    [HideInInspector]
    public Rigidbody interactObjectRigidbody;
    public void Initialize(Rigidbody interactObjectRigidbody)
    {
        this.interactObjectRigidbody = interactObjectRigidbody;
    }
    private void Start()
    {
        InitializeComponents();
    }
    public void InteractObjectRotate()
    {
        gameObject.transform.Rotate(interactObjectRotationDirection * rotationSpeed * Time.deltaTime);
    }   
    private float RandomRotationSpeed()
    {
        int randomIndex = Random.Range(0, 4);        
        
        switch (randomIndex)
        {
            case 0:
                rotationSpeed = 25;
                break;
            case 1:
                rotationSpeed = -50;
                break;
            case 2:
                rotationSpeed = 50;
                break;
            default:
                rotationSpeed = 0;
                break;
        }
        return rotationSpeed;
    }
    private float RandomForceValue()
    {
        float randomForceValue = Random.Range(minForce, maxForce);
        return randomForceValue;

    }
    protected virtual void InitializeComponents()
    {
        InteractObjectApplyForce();
        RandomRotationSpeed();

    }
    public void InteractObjectApplyForce()
    {
        interactObjectRigidbody.AddForce(gameObject.transform.up * RandomForceValue(), ForceMode.Impulse);
    }
    
    


}
