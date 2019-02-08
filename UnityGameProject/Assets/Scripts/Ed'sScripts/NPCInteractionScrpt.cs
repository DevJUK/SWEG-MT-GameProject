using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractionScrpt : MonoBehaviour
{
    // Are you talking with a npc or not?
    public bool Interacting;

    // Dictates who starts talking first in conversation
    public bool PlayerTalksFirst;

    // The canvas that will hold all of the text boxes for dialogue
    public GameObject InteractionCanvas;

    // Used to signify whos talking in conversation
    public Text WhosTalking;
    public string PlayerName;
    public string NPCName;

    // Textbox where dialogue will go
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
