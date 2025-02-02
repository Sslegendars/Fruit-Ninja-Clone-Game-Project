public class ComboSystem
{
    private int comboCount = 0;
    private float comboTimer;
    private float maxComboDuration = 1.2f; 
    public int minmNumOfFruitsToBeCut = 2;
    public bool IsComboActive { get; private set; } = false;

    public ComboSystem()
    {
        ResetCombo();
    }
    public void AddToCombo()
    {
        if (!IsComboActive)
        {
            IsComboActive = true;            
        }
        comboCount++;
    }
    public void UpdateCombo(float deltaTime)
    {
        comboTimer -= deltaTime;
        if (comboTimer <= 0f)
        {
            IsComboActive = false;
        }
    }

    public int GetComboCount()
    {
        return comboCount;
    }

    public void ResetCombo()
    {
        comboCount = 0;
        comboTimer = maxComboDuration;
        IsComboActive = false;

    }
}





