using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerWinAndLoseData 
{
    public PlayerStats Player1Stats { get; private set; }

    // Oyuncu 2'nin kazan� ve kay�plar�n� saklar
    public PlayerStats Player2Stats { get; private set; }

    // Bu s�n�f� ba�lat�r
    public MultiPlayerWinAndLoseData()
    {
        Player1Stats = new PlayerStats();
        Player2Stats = new PlayerStats();
    }

    // Oyuncu 1'in kazand���n� belirtir
    public void Player1Wins()
    {
        Player1Stats.Wins++;
        Player2Stats.Losses++;
    }

    // Oyuncu 2'nin kazand���n� belirtir
    public void Player2Wins()
    {
        Player2Stats.Wins++;
        Player1Stats.Losses++;
    }

     

    // �ki oyuncunun da istatistiklerini s�f�rlar
    public void ResetData()
    {
        Player1Stats.Reset();
        Player2Stats.Reset();
    }
}
