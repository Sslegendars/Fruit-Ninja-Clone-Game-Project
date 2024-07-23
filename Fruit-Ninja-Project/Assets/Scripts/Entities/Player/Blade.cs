using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{   
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    public bool Slicing { get; private set; }
    public Vector3 direction { get; private set; }
    public Camera MainCamera
    {
        get => mainCamera;
        set => mainCamera = value;
    }

    public Collider BladeCollider
    {
        get => bladeCollider;
        set => bladeCollider = value;
    }

    public TrailRenderer BladeTrail
    {
        get => bladeTrail;
        set => bladeTrail = value;
    }

    private void OnEnable()
    {
        StopSlicing();
    }
    private void OnDisable()
    {
        StopSlicing();
    }  
    
    public void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -2f;
        transform.position = newPosition;
        Slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.Clear();
    }
    public void StopSlicing()
    {
        Slicing = false;
        bladeCollider.enabled = false;
    }
    public void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -2f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
        
    }
}
