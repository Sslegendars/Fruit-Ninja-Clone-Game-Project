
public class BombMovement : Movement
{
    private const float xRotation = -90f;
    private const float yRotation = 0;
    private const float zRotation = 0;
    protected override void InitializeComponents()
    {      
              
        base.InitializeComponents();
        //BombRotationWhenSpawned();
        SetBombRotationDirection();
        InteractObjectRotationWhenGameIsStart(xRotation, yRotation, zRotation);


    }
    private UnityEngine.Vector3 SetBombRotationDirection()
    {
        interactObjectRotationDirection = new UnityEngine.Vector3(0, 1, 1);
        return interactObjectRotationDirection;
    }  
    
   
   
}
