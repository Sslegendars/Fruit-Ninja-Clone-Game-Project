
using UnityEngine;

public class FruitInitializer : InteractObjectInitializer
{
    protected FruitMovement fruitMovement;
    protected FruitController fruitController;
    public GameObject fruitJuice;
    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        fruitMovement = (FruitMovement)interactObjectMovement;
        fruitController = (FruitController)interactObjectController;
        fruitMovement.Initialize(interactObjectRigidbody);
        fruitController.Initialize(_collider, fruitMovement,fruitJuice);
    }
}
