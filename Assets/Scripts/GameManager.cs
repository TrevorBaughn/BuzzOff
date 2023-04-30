using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static (stays same) game manager instance
    public static GameManager instance;
    public static AudioManager audioManager;

    public UIGameplay uiGameplay;
    public DeathTimer deathTimer;

    [Header("Lists")]
    public List<PlayerController> players;
    public List<AIController> ais;
    public List<Beehive> hives;


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsGameObject;
    [SerializeField] private GameObject gameplayStateObject;


    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreenState();

        //attach audiomanager to gamemanager
        audioManager = AudioManager.instance;
    }

    private void ResetGame()
    {
        foreach (PlayerController player in players)
        {
            player.honey = 0;
            player.gameObject.transform.position = new Vector3(0, -5, 0);
        }

        foreach (AIController bees in ais)
        {
            bees.gameObject.transform.position = new Vector3(0, 0, 0);
            bees.currentState = AIController.AIStates.Idle;
        }

        foreach(Beehive hive in hives)
        {
            hive.honey = hive.baseHoney;
            hive.regenTimer = hive.timeToRegen;
            hive.collectTimer = hive.timeToCollect;
            hive.isPlayerInside = false;
        }

        deathTimer.timeTilDeath = deathTimer.timeToLive;
    }


    //deactivate all gamestates
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        controlsStateObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        gameOverStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsStateObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsStateObject.SetActive(true);
    }

    public void ActivateCreditsState()
    {
        DeactivateAllStates();
        creditsGameObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        ResetGame();
        DeactivateAllStates();
        gameplayStateObject.SetActive(true);
    }
}
