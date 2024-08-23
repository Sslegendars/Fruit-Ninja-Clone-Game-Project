using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectInitializer : MonoBehaviour
{
    public InteractObjectMovement interactObjectMovement;
    public InteractObjectController interactObjectController;
    protected Collider _collider;
    protected Rigidbody interactObjectRigidbody;

    private void Awake()
    {
        InitializeComponents();
    }
    protected virtual void InitializeComponents()
    {
        _collider = GetComponent<Collider>();
        interactObjectRigidbody = GetComponent<Rigidbody>();
        interactObjectMovement.Initialize(interactObjectRigidbody);
    }
}
