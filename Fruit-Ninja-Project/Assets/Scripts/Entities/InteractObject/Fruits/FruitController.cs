using UnityEngine;
public class FruitController : InteractObjectController
{
    private GameObject slicedFruitDown;
    private GameObject slicedFruitUp;
    private GameObject wholeFruit;
    private GameObject slicedFruit;
    private GameObject fruitJuice;
    private FruitMovement fruitMovement;
    private Collider fruitCollider;            
    private bool isFruitSliced = false;   
    
    
    private Vector3[] initialPosition = new Vector3[6];
    private Quaternion[] initialRotation = new Quaternion[6];
    private Vector3[] initialScale = new Vector3[6];
   
    public void Initialize(Collider fruitCollider, FruitMovement fruitMovement, GameObject fruitJuice, GameObject wholeFruit, GameObject slicedFruit, GameObject slicedFruitDown, GameObject slicedFruitUp)
    {
        this.fruitCollider = fruitCollider;
        this.fruitMovement = fruitMovement;
        this.fruitJuice = fruitJuice;
        this.wholeFruit = wholeFruit;
        this.slicedFruit = slicedFruit;
        this.slicedFruitDown = slicedFruitDown;
        this.slicedFruitUp = slicedFruitUp;
    }
    private void Awake()
    {
        SaveInitialState();
    }

    protected override void OnEnable()
    {
        ResetInitialState();
        ResetRigidbodyState();
        base.OnEnable();
        StartCoroutine(InitializeFruitAfterDelay());
    }

    private System.Collections.IEnumerator InitializeFruitAfterDelay()
    {
        yield return null;  // Wait for a frame to load all components
        InitializeComponents();
    }

    private void ResetRigidbodyState()
    {
        if (!fruitMovement.interactObjectRigidbody.isKinematic)
        {
            fruitMovement.interactObjectRigidbody.velocity = Vector3.zero;
            fruitMovement.interactObjectRigidbody.angularVelocity = Vector3.zero;
        }

        MakeFruitDynamicRigidbody();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ResetInitialState();
        if (isFruitSliced)
        {
            ChangeIsFruitSlicedState(false);
        }
    }

    private void Update()
    {
        FruitMovementWhenGameIsPlay();
        DestroyFruitWhenGameIsOver();
    }    

    // Component Initialization
    protected virtual void InitializeComponents()
    {
        FruitMovementWhenGameIsStart();
        ActivateWholeFruit();
        DeactivateSlicedFruit();
        DeactivateFruitJuice();
        EnableFruitCollider();
    }

    protected override void HandleBladeCollision(Collider bladeCollider)
    {
        Blade blade = bladeCollider.GetComponent<Blade>();
        Slice(blade.direction, blade.transform.position, blade.sliceForce);
        GameManager.Instance.OnFruitCut(blade.PlayerID);
        PlayFruitCutSound();
    }

    // Slice the fruit
    public void Slice(Vector3 direction, Vector3 position, float force)
    {
        ChangeIsFruitSlicedState(true);
        DeactivateWholeFruit();
        ActivateSlicedFruit();
        ActivateFruitJuice();
        MakeFruitKinematicRigidbody();
        DisableFruitCollider();
        RotateObjectAccordingCuttingAngle(direction);
        ApplyForceToSlices(direction, position, force);
    }

    private Quaternion RotateObjectAccordingCuttingAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 currentRotation = slicedFruit.transform.rotation.eulerAngles;
        slicedFruit.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);
        return slicedFruit.transform.rotation;
    }

    private void ApplyForceToSlices(Vector3 direction, Vector3 position, float force)
    {
        Rigidbody[] slices = slicedFruit.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitMovement.interactObjectRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private bool ChangeIsFruitSlicedState(bool isFruitSliced)
    {
        return this.isFruitSliced = isFruitSliced;
    }

    private void FruitMovementWhenGameIsStart()
    {
        fruitMovement.InteractObjectApplyForce();
    }

    private void FruitMovementWhenGameIsPlay()
    {
        if (!isFruitSliced)
        {
            fruitMovement.InteractObjectRotate();
        }
    }

    protected void DestroyFruitWhenGameIsOver()
    {
        if (GameManager.Instance.GameIsOver)
        {
            StopFruitCutSound();
            gameObject.SetActive(false);
        }
    }

    // Activate/Deactivate Methods
    private void DeactivateWholeFruit()
    {
        if (wholeFruit.activeSelf)
            wholeFruit.SetActive(false);
    }

    private void ActivateWholeFruit()
    {
        if (!wholeFruit.activeSelf)
            wholeFruit.SetActive(true);
    }

    private void ActivateSlicedFruit()
    {
        if (!slicedFruit.activeSelf)
            slicedFruit.SetActive(true);
    }

    private void DeactivateSlicedFruit()
    {
        if (slicedFruit.activeSelf)
            slicedFruit.SetActive(false);
    }

    private void ActivateFruitJuice()
    {
        if (!fruitJuice.activeSelf)
            fruitJuice.SetActive(true);
    }

    private void DeactivateFruitJuice()
    {
        if (fruitJuice.activeSelf)
            fruitJuice.SetActive(false);
    }

    private void EnableFruitCollider()
    {
        if (!fruitCollider.enabled)
            fruitCollider.enabled = true;
    }

    private void DisableFruitCollider()
    {
        if (fruitCollider.enabled)
            fruitCollider.enabled = false;
    }

    private void MakeFruitKinematicRigidbody()
    {
        if (!fruitMovement.interactObjectRigidbody.isKinematic)
            fruitMovement.interactObjectRigidbody.isKinematic = true;
    }

    private void MakeFruitDynamicRigidbody()
    {
        if (fruitMovement.interactObjectRigidbody.isKinematic)
            fruitMovement.interactObjectRigidbody.isKinematic = false;
    }

    private void PlayFruitCutSound()
    {
        AudioManager.Instance?.Play(SoundName.FruitCutSound);
    }

    private void StopFruitCutSound()
    {
        AudioManager.Instance?.Stop(SoundName.FruitCutSound);
    }

    // Save and Reset Initial State
    public void SaveInitialState()
    {
        // Ana meyve
        initialPosition[0] = wholeFruit.transform.localPosition;
        initialRotation[0] = wholeFruit.transform.localRotation;
        initialScale[0] = wholeFruit.transform.localScale;

        // Kesilmiþ meyve
        initialPosition[1] = slicedFruit.transform.localPosition;
        initialRotation[1] = slicedFruit.transform.localRotation;
        initialScale[1] = slicedFruit.transform.localScale;

        // Meyve suyu
        initialPosition[2] = fruitJuice.transform.localPosition;
        initialRotation[2] = fruitJuice.transform.localRotation;
        initialScale[2] = fruitJuice.transform.localScale;

        // Sliced fruit Down
        initialPosition[3] = slicedFruitDown.transform.localPosition;
        initialRotation[3] = slicedFruitDown.transform.localRotation;
        initialScale[3] = slicedFruitDown.transform.localScale;

        // Sliced Fruit Up
        initialPosition[4] = slicedFruitUp.transform.localPosition;
        initialRotation[4] = slicedFruitUp.transform.localRotation;
        initialScale[4] = slicedFruitUp.transform.localScale;

        // Fruit Parent Object
        initialPosition[5] = gameObject.transform.position;
        initialRotation[5] = gameObject.transform.rotation;
        initialScale[5] = gameObject.transform.localScale;
    }

    private void ResetInitialState()
    {
        // wholeFruit durumunu geri yükle
        wholeFruit.transform.localPosition = initialPosition[0];
        wholeFruit.transform.localRotation = initialRotation[0];
        wholeFruit.transform.localScale = initialScale[0];

        // slicedFruit durumunu geri yükle
        slicedFruit.transform.localPosition = initialPosition[1];
        slicedFruit.transform.localRotation = initialRotation[1];
        slicedFruit.transform.localScale = initialScale[1];

        // fruitJuice durumunu geri yükle
        fruitJuice.transform.localPosition = initialPosition[2];
        fruitJuice.transform.localRotation = initialRotation[2];
        fruitJuice.transform.localScale = initialScale[2];

        // Sliced Fruit Down
        slicedFruitDown.transform.localPosition = initialPosition[3];
        slicedFruitDown.transform.localRotation = initialRotation[3];
        slicedFruitDown.transform.localScale = initialScale[3];

        // Sliced Fruit Up
        slicedFruitUp.transform.localPosition = initialPosition[4];
        slicedFruitUp.transform.localRotation = initialRotation[4];
        slicedFruitUp.transform.localScale = initialScale[4];

        // Fruit Parent Object
        gameObject.transform.position = initialPosition[5];
        gameObject.transform.rotation = initialRotation[5];
        gameObject.transform.localScale = initialScale[5];
    }



}
