using UnityEngine;

public class InteractObjectMovement : MonoBehaviour
{    
    protected Vector3 interactObjectRotationDirection;
    [HideInInspector]
    public Rigidbody interactObjectRigidbody;
    public void Initialize(Rigidbody interactObjectRigidbody)
    {
        this.interactObjectRigidbody = interactObjectRigidbody;
    }
    
    public void InteractObjectRotate()
    {
        gameObject.transform.Rotate(interactObjectRotationDirection * InteractObjectRotationSpeed() * Time.deltaTime);
    }

    private float InteractObjectForceValue()
    {
        return SpawnManager.Instance.forceValue;
    }
    private float InteractObjectRotationSpeed()
    {
        return SpawnManager.Instance.prefabRotationSpeed;
    }
    public void InteractObjectApplyForce()
    {
        interactObjectRigidbody.AddForce(gameObject.transform.up * InteractObjectForceValue(), ForceMode.Impulse);
    }

}
