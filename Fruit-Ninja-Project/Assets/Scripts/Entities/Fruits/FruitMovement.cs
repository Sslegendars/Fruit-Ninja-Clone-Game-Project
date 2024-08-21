using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    private float minForce = 11f;
    private float maxForce = 15f;  
    [HideInInspector]
    public Rigidbody fruitRigidBody;
    public void Initialize(Rigidbody fruitRigidBody)
    {
        this.fruitRigidBody = fruitRigidBody;
    }
    public void FruitApplyForce()
    {
        fruitRigidBody.AddForce(gameObject.transform.up * RandomForceValue(), ForceMode.Impulse);
    }
    public void FruitRotate()
    {
        fruitRigidBody.AddTorque(Vector3.forward * RandomTorqueValue());
    }
   
    private float RandomForceValue()
    {
        float randomForceValue = Random.Range(minForce, maxForce);
        return randomForceValue;

    }
    private float RandomTorqueValue()
    {
        float torque = Random.Range(-2, 2);
        return torque;
    }
}
