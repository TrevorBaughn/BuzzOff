using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI honeyText;
    [SerializeField] private TextMeshProUGUI timerText;


    public void UpdateHoneyScoreText()
    {
        if(GameManager.instance.players.Count > 0)
        {
            honeyText.text = GameManager.instance.players[0].honey.ToString();
        }
    }

    public void UpdateTimerText()
    {
        timerText.text = GameManager.instance.deathTimer.timeTilDeath.ToString();
    }

}
