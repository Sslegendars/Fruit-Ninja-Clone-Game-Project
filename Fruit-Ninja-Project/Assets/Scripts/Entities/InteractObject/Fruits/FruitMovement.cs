public class FruitMovement : Movement
{      
    protected override void InitializeComponents()
    {
        minForce = 11f;
        maxForce = 15f;
        interactObjectRotationDirection = new UnityEngine.Vector3(1, 0, 1);
        base.InitializeComponents();
    }
}
