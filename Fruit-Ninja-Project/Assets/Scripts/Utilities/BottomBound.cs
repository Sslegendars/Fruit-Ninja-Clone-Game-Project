using System.Collections;
using System.Collections.Generic;
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
        if (fruitCollider.CompareTag("Fruit"))
        {
            PlayerLoseLife();
        }         
             
    }
    private void PlayerLoseLife()
    {
        playerLives.DecreaseLife();
    }
}
