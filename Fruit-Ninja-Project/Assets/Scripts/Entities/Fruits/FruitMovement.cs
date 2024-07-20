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
    private void Start()
    {
        fruitApplyForce();
    }
    private void fruitApplyForce()
    {
        fruitRigidBody.AddForce(gameObject.transform.up * RandomForceValue(), ForceMode.Impulse);
    }
    private float RandomForceValue()
    {
        float randomForceValue = Random.Range(minForce, maxForce);
        return randomForceValue;

    }
}
