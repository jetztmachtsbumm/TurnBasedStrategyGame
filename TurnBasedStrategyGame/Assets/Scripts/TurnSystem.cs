using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public static TurnSystem Instance { get; private set; }

    public event EventHandler<int> OnTurnNumberChanged;

    private int turnNumber = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void NextTurn()
    {
        turnNumber++;
        OnTurnNumberChanged?.Invoke(this, turnNumber);
    }

}
