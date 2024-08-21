using UnityEngine;

public class InteractObjectController : MonoBehaviour
{
    private const float maxLifeTime = 5f;
    protected void DestroyGameObjectDepentOnTime()
    {
        Destroy(gameObject, maxLifeTime);
    }
    protected void DestroyGameObjectWhenGameIsOver()
    {
        if (GameManager.Instance.GameIsOver == true)
        {
            Destroy(gameObject);
        }
    }
}
