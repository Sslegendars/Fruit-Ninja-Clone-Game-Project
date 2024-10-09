using UnityEngine;
public class FruitInitializer : InteractObjectInitializer<FruitMovement, FruitController>
{
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
        interactObjectController.Initialize(_collider, interactObjectMovement, fruitJuice, wholeFruit, slicedFruit, slicedFruitDown, slicedFruitUp);
    }
}
