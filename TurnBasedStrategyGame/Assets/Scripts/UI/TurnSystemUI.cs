using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystemUI : MonoBehaviour
{

    [SerializeField] private Button endTurnButton;
    [SerializeField] private TextMeshProUGUI turnNumberText;

    private void Awake()
    {
        endTurnButton.onClick.AddListener(EndTurn);
    }

    private void Start()
    {
        TurnSystem.Instance.OnTurnNumberChanged += TurnSystem_OnTurnNumberChanged;
    }

    private void EndTurn()
    {
        TurnSystem.Instance.NextTurn();
    }

    private void TurnSystem_OnTurnNumberChanged(object sender, int turnNumber)
    {
        turnNumberText.text = "TURN " + turnNumber;
    }

}
