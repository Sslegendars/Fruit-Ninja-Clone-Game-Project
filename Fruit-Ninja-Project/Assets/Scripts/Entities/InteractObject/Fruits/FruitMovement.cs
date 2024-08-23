public class FruitMovement : InteractObjectMovement
{      
    protected override void InitializeComponents()
    {
        interactObjectRotationDirection = new UnityEngine.Vector3(0, 0, 1);
        base.InitializeComponents();
    }
   
}
