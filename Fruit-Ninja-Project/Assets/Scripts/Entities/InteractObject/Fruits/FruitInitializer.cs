using UnityEngine;
public class FruitInitializer : InteractObjectInitializer
{
    protected FruitMovement fruitMovement;
    protected FruitController fruitController;
    [SerializeField]
    private GameObject fruitJuice;
    [SerializeField]
    private GameObject wholeFruit;
    [SerializeField]
    private GameObject slicedFruit;
    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        fruitMovement = (FruitMovement)interactObjectMovement;
        fruitController = (FruitController)interactObjectController;
        fruitMovement.Initialize(interactObjectRigidbody);
        fruitController.Initialize(_collider, fruitMovement,fruitJuice, wholeFruit, slicedFruit);
    }
}
