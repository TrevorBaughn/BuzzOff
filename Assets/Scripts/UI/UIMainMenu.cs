using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    //Resets and starts game
    public void StartGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateGameplayState();
    }

    //opens options menu
    public void OptionsButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateOptionsState();
    }

    //opens controls menu
    public void ControlsButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateControlsState();
    }

    //opens credits menu
    public void CreditsButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateCreditsState();
    }

    //quits the game
    public void QuitGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
            GameManager.instance.ActivateTitleScreenState();
        }
    }
}
