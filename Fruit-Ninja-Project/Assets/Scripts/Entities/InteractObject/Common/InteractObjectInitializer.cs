using UnityEngine;
public class InteractObjectInitializer : MonoBehaviour
{   
    [SerializeField]
    protected InteractObjectMovement interactObjectMovement;
    [SerializeField]
    protected InteractObjectController interactObjectController;
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
