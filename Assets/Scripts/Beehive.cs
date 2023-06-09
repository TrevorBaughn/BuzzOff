using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour
{
    public bool isPlayerInside = false;
    [SerializeField] private HoneyBar honeyBar;

    [Header("Honey")]
    public int maxHoney;
    public int baseHoney;
    public int honey;

    [Header("Collection")]
    [SerializeField] private int honeyToTake;
    public float timeToCollect;
    public float collectTimer;

    [Header("Regeneration")]
    [SerializeField] private int honeyToRegen;
    public float timeToRegen;
    public float regenTimer;


    



    // Start is called before the first frame update
    void Start()
    {
        honey = baseHoney;

        collectTimer = timeToCollect;
        regenTimer = timeToRegen;

        GameManager.instance.hives.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (!isPlayerInside || (isPlayerInside && !GameManager.instance.players[0].pawn.isInteracting))
        {
            RegenHoney();
        }

        if(isPlayerInside && GameManager.instance.players[0].pawn.isInteracting)
        {
            CollectHoney(GameManager.instance.players[0]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.instance.players[0].gameObject)
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject == GameManager.instance.players[0].gameObject)
        {
            isPlayerInside = false;
            //if leave, force interact off
            GameManager.instance.players[0].pawn.isInteracting = false;
        }
    }

    private void CollectHoney(PlayerController player)
    {
        regenTimer = timeToRegen;
        collectTimer -= Time.deltaTime;
        if (collectTimer <= 0)
        {
            collectTimer = timeToCollect;
            Debug.Log("collecting...");

            //initial honey value (listen, I get this is stupid to reuse this variable)
            int honeyToGive = honey;
            
            //subtract the honey
            honey = Mathf.Clamp(honey - honeyToTake, 0, maxHoney);
            honeyBar.UpdateHoneyImage();

            //calculate the difference in original honey and current honey to give
            honeyToGive = honeyToGive - honey;
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.honey);

            //give player honey
            player.honey += honeyToGive;
            GameManager.instance.uiGameplay.UpdateHoneyScoreText();
        }


        
    }

    private void RegenHoney()
    {
        collectTimer = timeToCollect;
        regenTimer -= Time.deltaTime;
        if(regenTimer <= 0)
        {
            regenTimer = timeToRegen;

            //give honey
            honey = Mathf.Clamp(honey + honeyToRegen, 0, maxHoney);
            honeyBar.UpdateHoneyImage();

            Debug.Log("regenerating...");
        }


        
    }

    
}
