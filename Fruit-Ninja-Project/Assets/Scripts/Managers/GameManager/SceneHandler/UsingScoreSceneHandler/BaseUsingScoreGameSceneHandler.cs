using UnityEngine;
public abstract class BaseUsingScoreGameSceneHandler: ISceneHandler, ISceneHandlerFruitCutUpdatable, ISceneHandlerUpdatable,ISceneHandlerResumable
{
    protected Blade[] _blades;
    protected ComboSystem[] comboSystems; 
    protected ScoreManager scoreManager;

    public BaseUsingScoreGameSceneHandler()
    {
        scoreManager = new ScoreManager();
    }

    public virtual void Initialize()
    {
        InitializeComboSystem();
    }  
    private void InitializeComboSystem()
    {
        if (_blades == null || _blades.Length == 0) return; 
        comboSystems = new ComboSystem[_blades.Length];
        for (int i = 0; i < _blades.Length; i++)
        {
            comboSystems[i] = new ComboSystem();
        }
    }

    protected void CheckHandleCombo()
    {
        for (int i = 0; i < comboSystems.Length; i++)
        {
            if (comboSystems[i]?.IsComboActive == true) 
            {
                HandleCombo(i);
            }
        }
    }

    protected void HandleCombo(int playerID)
    {
        if (playerID < comboSystems.Length)
        {
            ComboSystem comboSystem = comboSystems[playerID];
            comboSystem.UpdateCombo(Time.deltaTime);

            if (!comboSystem.IsComboActive)
            {
                int pointsToAdd = CalculateAndShowComboPoints(playerID);
                
                scoreManager.UpdateScore(playerID, pointsToAdd);
                comboSystem.ResetCombo();
            }
        }
    }

    protected int CalculateAndShowComboPoints(int playerID)
    {
        if (playerID < comboSystems.Length)
        {
            ComboSystem comboSystem = comboSystems[playerID];
            int comboCount = comboSystem.GetComboCount();
            if (comboCount > comboSystem.minmNumOfFruitsToBeCut)
            {   
                int pointsToAdd = (comboCount - comboSystem.minmNumOfFruitsToBeCut) * 10;
                UIManager.Instance.comboHandler.ShowComboText(pointsToAdd, playerID, _blades[playerID].transform.position);
                AudioManager.Instance.Play(SoundName.ComboAddPointsSound);
                return pointsToAdd;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }

    public void FruitCutUpdate(int playerID)
    {
        if (playerID < comboSystems.Length)
        {
            ComboSystem comboSystem = comboSystems[playerID];
            scoreManager.UpdateScore(playerID, 1);
            comboSystem.AddToCombo();
        }
    }    
    public abstract void Update();
    public abstract void GameOver();
    public abstract void ResumeTheGame();

}
