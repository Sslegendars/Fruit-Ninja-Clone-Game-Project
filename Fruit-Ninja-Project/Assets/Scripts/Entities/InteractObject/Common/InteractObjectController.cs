using UnityEngine;
using System.Collections;

public abstract class InteractObjectController : MonoBehaviour
{   
    
    private const float maxLifeTime = 6f;
    protected virtual void OnEnable()
    {
        DeactivateGameObjectAfterDelay();
    }
    protected virtual void OnDisable()
    {
        StopCoroutine(DeactivateGameObjectCoroutine());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            HandleBladeCollision(other);
        }
    }
    private void DeactivateGameObjectAfterDelay()
    {
        StartCoroutine(DeactivateGameObjectCoroutine());
    }
    private IEnumerator DeactivateGameObjectCoroutine()
    {
        yield return new WaitForSeconds(maxLifeTime);
        gameObject.SetActive(false);
        
    }
    protected abstract void HandleBladeCollision(Collider bladeCollider);

}
