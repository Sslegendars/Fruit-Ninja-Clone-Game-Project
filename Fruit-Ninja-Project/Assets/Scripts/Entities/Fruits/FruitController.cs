using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private FruitMovement fruitMovement;
    private Collider fruitCollider;

    private const float maxLifeTime = 5f;
    
    private void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
    }
    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;

        RotateObjectAccordingCuttingAngle(direction);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = fruitMovement.fruitRigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
   
    private Quaternion RotateObjectAccordingCuttingAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       
        sliced.transform.rotation = Quaternion.Euler(angle, sliced.transform.rotation.y, sliced.transform.rotation.z);
        return sliced.transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}
