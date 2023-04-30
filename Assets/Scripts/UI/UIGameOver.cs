using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI honeyText;
    

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

    private void OnEnable()
    {
        UpdateHoneyScoreText();
        UpdateTimerText();
    }


    //Resets and restarts game
    public void RestartGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateGameplayState();
    }

    //returns to main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    //quits the game
    public void QuitGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        Application.Quit();
    }
}