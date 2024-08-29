public class FruitMovement : InteractObjectMovement
{
    private void Start()
    {
        FruitRotationDirection();
    }
    private void FruitRotationDirection()
    {
        interactObjectRotationDirection = new UnityEngine.Vector3(0, 0, 1);
    }
   
}
