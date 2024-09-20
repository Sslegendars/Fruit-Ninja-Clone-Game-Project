using UnityEngine;

public abstract class BaseUsingScoreGameSceneHandler: ISceneHandler, ISceneHandlerFruitCutUpdatable, ISceneHandlerUpdatable
{
    protected Blade[] _blades;
    protected ComboSystem[] comboSystems; // ComboSystem dizisi
    protected ScoreManager scoreManager;

    public BaseUsingScoreGameSceneHandler()
    {
        scoreManager = new ScoreManager();
    }

    public virtual void Initialize()
    {
        InitializeComboSystem();
    }

    public abstract void Update();
    public abstract void GameOver();

    private void InitializeComboSystem()
    {
        if (_blades == null || _blades.Length == 0) return; // Null veya boþ kontrolü
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
            if (comboSystems[i]?.IsComboActive == true) // Null kontrolü ve IsComboActive kontrolü
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
                int pointsToAdd = CalculateComboPoints(playerID);
                UIManager.Instance.comboHandler.ShowComboText(pointsToAdd, playerID, _blades[playerID].transform.position);
                scoreManager.UpdateScore(playerID, pointsToAdd);
                comboSystem.ResetCombo();
            }
        }
    }

    protected int CalculateComboPoints(int playerID)
    {
        if (playerID < comboSystems.Length)
        {
            ComboSystem comboSystem = comboSystems[playerID];
            int comboCount = comboSystem.GetComboCount();
            if (comboCount > comboSystem.minmNumOfFruitsToBeCut)
            {
                return (comboCount - comboSystem.minmNumOfFruitsToBeCut) * 10;
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

}
