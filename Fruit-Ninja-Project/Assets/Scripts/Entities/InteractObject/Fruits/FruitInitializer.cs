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
    [SerializeField]
    private GameObject slicedFruitDown;
    [SerializeField]
    private GameObject slicedFruitUp;
    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        fruitMovement = (FruitMovement)interactObjectMovement;
        fruitController = (FruitController)interactObjectController;
        fruitController.Initialize(_collider, fruitMovement,fruitJuice, wholeFruit, slicedFruit, slicedFruitDown, slicedFruitUp);
    }
}
