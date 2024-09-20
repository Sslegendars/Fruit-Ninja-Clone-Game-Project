using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerWinAndLoseData 
{
    public PlayerStats Player1Stats { get; private set; }

    // Oyuncu 2'nin kazanç ve kayýplarýný saklar
    public PlayerStats Player2Stats { get; private set; }

    // Bu sýnýfý baþlatýr
    public MultiPlayerWinAndLoseData()
    {
        Player1Stats = new PlayerStats();
        Player2Stats = new PlayerStats();
    }

    // Oyuncu 1'in kazandýðýný belirtir
    public void Player1Wins()
    {
        Player1Stats.Wins++;
        Player2Stats.Losses++;
    }

    // Oyuncu 2'nin kazandýðýný belirtir
    public void Player2Wins()
    {
        Player2Stats.Wins++;
        Player1Stats.Losses++;
    }

     

    // Ýki oyuncunun da istatistiklerini sýfýrlar
    public void ResetData()
    {
        Player1Stats.Reset();
        Player2Stats.Reset();
    }
}
