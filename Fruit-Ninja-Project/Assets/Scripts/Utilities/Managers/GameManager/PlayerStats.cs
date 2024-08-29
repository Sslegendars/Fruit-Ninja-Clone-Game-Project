using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    public int Wins { get; set; }
    public int Losses { get; set; }

    public void Reset()
    {
        Wins = 0;
        Losses = 0;
    }
}
