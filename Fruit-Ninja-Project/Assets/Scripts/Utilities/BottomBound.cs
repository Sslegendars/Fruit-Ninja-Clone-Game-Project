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
        if (GameManager.Instance.GameIsOver == false && fruitCollider.CompareTag("Fruit"))
        {
            PlayerLoseLife();
        }         
             
    }
    private void PlayerLoseLife()
    {
        playerLives.DecreaseLife();
    }
}
