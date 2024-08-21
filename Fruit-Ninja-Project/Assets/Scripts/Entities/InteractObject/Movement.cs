using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectMovement : MonoBehaviour
{
    protected float minForce = 11;
    protected float maxForce = 15;

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
    public void InteractObjectMovement()
    {
        gameObject.transform.Rotate(interactObjectRotationDirection * rotationSpeed * Time.deltaTime);
    }
    protected void InteractObjectRotationWhenGameIsStart(float xRotation, float yRotation, float zRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
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
    private void InteractObjectApplyForce()
    {
        interactObjectRigidbody.AddForce(gameObject.transform.up * RandomForceValue(), ForceMode.Impulse);
    }
    


}
