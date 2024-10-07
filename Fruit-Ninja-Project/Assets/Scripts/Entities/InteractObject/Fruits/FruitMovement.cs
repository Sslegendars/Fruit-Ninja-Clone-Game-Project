public class FruitMovement : InteractObjectMovement
{
    private void Start()
    {
        FruitRotationDirection();
    }
    private UnityEngine.Vector3 FruitRotationDirection()
    {
        interactObjectRotationDirection = new UnityEngine.Vector3(0, 0, 1);
        return interactObjectRotationDirection;
    }

}
