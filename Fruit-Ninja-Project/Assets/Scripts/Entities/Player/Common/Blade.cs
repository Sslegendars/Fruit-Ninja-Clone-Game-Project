using UnityEngine;

public class Blade : MonoBehaviour
{
    private int playerID;
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    
    [HideInInspector]
    public float sliceForce = 5f;
    private float minSliceVelocity = 0.01f;

    private float angleThreshold = 90f;
    private Vector3 previousDirection;

    public bool Slicing { get; private set; }
    public Vector3 direction { get; private set; }

    private Vector3 lastTouchPosition; 

    public Camera MainCamera
    {
        get => mainCamera;
        set => mainCamera = value;
    }

    public Collider BladeCollider
    {
        get => bladeCollider;
        set => bladeCollider = value;
    }

    public TrailRenderer BladeTrail
    {
        get => bladeTrail;
        set => bladeTrail = value;
    }
    public int PlayerID
    {
        get => playerID;
        set => playerID = value;
    }

    private void Start()
    {
        StopSlicing();
    }

    public void StartSlicing(Vector2 touchPosition)
    {
        lastTouchPosition = touchPosition;
        Vector3 newPosition = BladeNewPosition(touchPosition);
        transform.position = newPosition;
        Slicing = true;
        EnableBladeCollider();
        bladeTrail.Clear();
    }

    private void EnableBladeCollider()
    {
        bladeCollider.enabled = true;
    }

    private void DisableBladeCollider()
    {
        if (BladeCollider != null)
            bladeCollider.enabled = false;
    }

    public void StopSlicing()
    {
        Slicing = false;
        DisableBladeCollider();
    }

    public void ContinueSlicing(Vector2 touchPosition)
    {
        Vector3 newPosition = BladeNewPosition(touchPosition);
        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;
        transform.position = newPosition;
        CheckAngleChangeAndPlayMusic();
        lastTouchPosition = touchPosition;
    }

    private Vector3 BladeNewPosition(Vector2 touchPosition)
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane));
        newPosition.z = -2f;
        return newPosition;
    }
    private void CheckAngleChangeAndPlayMusic()
    {
        if (IsInSinglePlayerScene())
        {
            if (HasDirectionChangedSignificantly())
            {
                PlayBladeSwipeSound();
            }

            previousDirection = direction; 
        }
    }

    private bool IsInSinglePlayerScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SinglePlayerGameScene";
    }

    private bool HasDirectionChangedSignificantly()
    {
        if (previousDirection != Vector3.zero)
        {
            float angleDifference = Vector3.Angle(previousDirection, direction);
            return angleDifference > angleThreshold; 
        }

        return false; 
    }

    private void PlayBladeSwipeSound()
    {
        AudioManager.Instance.PlayRandomBladeSwipeSound();
        
    }
    
}
