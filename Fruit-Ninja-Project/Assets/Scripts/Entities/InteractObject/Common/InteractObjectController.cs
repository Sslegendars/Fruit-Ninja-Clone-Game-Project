using UnityEngine;
using System.Collections;

public class InteractObjectController : MonoBehaviour
{   
    
    private const float maxLifeTime = 6f;
    protected virtual void OnEnable()
    {
        DeactivateGameObjectDepentOnTime();
    }
    protected virtual void OnDisable()
    {
        StopCoroutine(DeactivateGameObjectCoroutine());
    }
    private void DeactivateGameObjectDepentOnTime()
    {
        StartCoroutine(DeactivateGameObjectCoroutine());
    }
    private IEnumerator DeactivateGameObjectCoroutine()
    {
        yield return new WaitForSeconds(maxLifeTime);
        gameObject.SetActive(false);
        
    }
    

}
