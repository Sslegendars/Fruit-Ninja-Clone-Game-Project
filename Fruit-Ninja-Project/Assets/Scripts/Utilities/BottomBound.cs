using UnityEngine;

public class BottomBound : MonoBehaviour
{
    [SerializeField]
    private PlayerLives playerLives;

    private void OnTriggerEnter(Collider other)
    {
       HandleFruitCollision(other);        
    }
    private void HandleFruitCollision(Collider fruitCollider)
    {   
        if(GameManager.Instance.GameIsOver == false)
        {
            if (
            fruitCollider.CompareTag("AppleFruit") ||
            fruitCollider.CompareTag("CoconutFruit") ||
            fruitCollider.CompareTag("OrangeFruit") ||
            fruitCollider.CompareTag("PearFruit") ||
            fruitCollider.CompareTag("WatermelonFruit")
            )
            {
                PlayerLoseLife();
            }
        }
                 
             
    }
    private void PlayerLoseLife()
    {
        playerLives.DecreaseLife();
    }
}
