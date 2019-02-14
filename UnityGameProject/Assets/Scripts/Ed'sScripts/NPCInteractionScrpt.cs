using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractionScrpt : MonoBehaviour
{
    // Are you talking with a npc or not?
    [Header("Interacting with the NPC")]
    [Tooltip("Is the player interacting with the NPC")]
    public bool Interacting;

    // Dictates who starts talking first in conversation
    [Header("Whos talking first")]
    [Tooltip("If true the player is talking first. If false the NPC will talk first")]
    public bool PlayerTalksFirst;

    // The canvas that will hold all of the text boxes for dialogue
    [Header("Canvas")]
    [Tooltip("The canvas that will hold all of the text boxes for dialogue")]
    public GameObject InteractionCanvas;

    // Used to signify whos talking in conversation
    [Header("Whos Talking")]
    [Tooltip("Text box where the current talkers name goes")]
    public Text WhosTalking;
    [Tooltip("Players name goes here")]
    public string PlayerName;
    [Tooltip("NPC's name goes here")]
    public string NPCName;

    // Textbox where player dialogue will go
    [Header("Player dialogue lines")]
    [Tooltip("Put any dialogue you want the player to say in here, remember to use the in text triggers")]
    public Text DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the dialogue box is empty when script is run
        DialogueBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ShowHideInteractionUI();

        if (Interacting)
        {
            if (PlayerTalksFirst)
            {
                WhosTalking.text = PlayerName;
            }
            else
            {
                WhosTalking.text = NPCName;
            }
        }
    }

    public void StartInteraction() // Call this to start interacting..... duh
    {
        Interacting = true;
    }

    public void ShowHideInteractionUI() // If interacting with NPC bring up ui element with text etc...
    {
        if (Interacting)
        {
            InteractionCanvas.SetActive(true);
        }
        else
        {
            InteractionCanvas.SetActive(false);
        }
    }
}
