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
        if (SpawnManager.Instance == null)
        {
            return 0;            
        }            
        else
        {
            return SpawnManager.Instance.prefabForceValue;
        }
        
    }
    private float InteractObjectRotationSpeed()
    {   
        if (SpawnManager.Instance != null)
            return SpawnManager.Instance.prefabRotationSpeed;
        else
            return 0;        
    }  
   
    public void InteractObjectApplyForce()
    {   
        float force = InteractObjectForceValue();  
        interactObjectRigidbody.AddForce(gameObject.transform.up * force, ForceMode.Impulse);
        
       
    }

}
