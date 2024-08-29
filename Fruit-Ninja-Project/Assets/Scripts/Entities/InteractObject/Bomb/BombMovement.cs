
public class BombMovement : InteractObjectMovement
{
    private void Start()
    {
        SetBombRotationDirection();
    }
    private UnityEngine.Vector3 SetBombRotationDirection()
    {
        interactObjectRotationDirection = new UnityEngine.Vector3(0, 0, 1);
        return interactObjectRotationDirection;
    }
    public void ObjectRigidbodyIsKinematic()
    {
        interactObjectRigidbody.isKinematic = true;
    }



}
