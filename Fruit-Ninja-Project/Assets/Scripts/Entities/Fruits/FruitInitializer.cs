using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInitializer : MonoBehaviour
{
    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    public FruitMovement fruitMovement;
    public FruitController fruitController;
    private void Awake()
    {
        InitializeComponents();
    }
    private void InitializeComponents()
    {
        fruitCollider = GetComponent<Collider>();
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitMovement.Initialize(fruitRigidbody);
        fruitController.Initialize(fruitCollider, fruitMovement);
    }
}
