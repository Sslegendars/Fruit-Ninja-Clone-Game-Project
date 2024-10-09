using UnityEngine;
public class InteractObjectInitializer<TMovement, TController> : MonoBehaviour
    where TMovement : InteractObjectMovement
    where TController : InteractObjectController
{
    [SerializeField]
    protected TMovement interactObjectMovement;
    [SerializeField]
    protected TController interactObjectController;

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

