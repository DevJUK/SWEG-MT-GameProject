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
    public bool PlayerTalking;

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
    [Header("Dialogue Box")]
    [Tooltip("Text box where the current dialogue line goes")]
    public Text DialogueBox;

    [Header("Player dialogue lines")]
    [Tooltip("Put any dialogue you want the player to say in here, remember to use the in text triggers")]
    public List<string> PlayerDialogue;

    private RaycastItems RaycastItems; // The script that tells us if we are looking at an item or npc
    private NPCDialogueScrpt NPCDialogueScrpt; // The script that has all the NPC's dialogue in it
    private bool NPCNameSet; // Has the NPC's name been set yet?

    [Header("Dialogue Path Values")]
    public int DialoguePath; // The path your currently on
    public int StartingDialoguePath; // The path youll start on
    public int CurrentPlayerDialoguePath; // The most recent path read from the player's dialogue
    public int CurrentNPCDialoguePath; // The most recent path read from the NPC'sdialogue
    public int LastDialoguePath; // The last dialogue path that was read

    [Header("Current Character number")]
    public int CharNo;

    [Header("Dialogue Value")]
    public string DialogueValue;

    [Header("Print Sentence In One Go")]
    [Tooltip("If true will print all of the sentence in one go. If false will print using typewriter effect")]
    public bool PrintSentenceInOneGo;

    [Header("Typewriter Coroutine Values")]
    public bool CoroutineStarted;
    public float CoroutineDelay;

    [Header("Position in Dialogue")]
    public bool EndOfSentence;
    public bool NewConversation;

    void Start()
    {
        // Make sure the dialogue box is empty when script is run
        DialogueBox.text = "";

        RaycastItems = GameObject.Find("Camera").GetComponent<RaycastItems>();
    }

    void Update()
    {
        ShowHideInteractionUI();

        if (Interacting)
        {
            if (!NPCNameSet) // If the NPC's name hasnt been set yet then set it
            {
                NPCName = NPCDialogueScrpt.NPCName;
            }

            if (PlayerTalksFirst) // Checking whos dialogue will come up first
            {
                WhosTalking.text = PlayerName;
                PlayerTalking = true;
            }
            else
            {
                WhosTalking.text = NPCName;
                PlayerTalking = false;
            }

            if (PlayerTalking)
            {
                if (NewConversation) // If this isnt the first conversation with the NPC then start at the last known dialogue path for that npc
                {
                    StartingDialoguePath = LastDialoguePath;
                }
                else
                {
                    StartingDialoguePath = NPCDialogueScrpt.PlayersStartingDiologuePath; // If it is the first conversation with the NPC then just use the player start point
                }
            }
            else
            {
                if (NewConversation) // If this isnt the first conversation with the NPC then start at the last known dialogue path for that npc
                {
                    {
                        StartingDialoguePath = LastDialoguePath;
                    }
                }
                else
                {
                    StartingDialoguePath = NPCDialogueScrpt.NPCsStartingDiologuePath; // If it is the first conversation with the NPC then just use the NPC start point
                }
            }
            ReadDialogue();
        }
    }

    public void StartInteraction() // Call this to start interacting..... duh
    {
        // Used to get the dialogue script from the NPC the player is currently interacting with
        NPCDialogueScrpt = GameObject.Find(RaycastItems.NameofNPCHit).GetComponent<NPCDialogueScrpt>(); 

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

    public void ReadDialogue() // Used to ditermine what to do i.e. print text or act on in text logic
    {
        Debug.Log("Read Dialogue");

        if (DialogueValue == "#End#") // Ends dialogue (use at the very end of dialogue to stop errors)
        {
            EndOfDialogueBlock();
            Debug.Log("End");
        }
        else if (DialogueValue.Contains("#Break#")) // Creates a break in the dialogue (use for whole new conversations i.e after the player walks off and does something)
        {
            BreakInDialogue();
            Debug.Log("Break");
        }
        
        else if (DialogueValue.Contains("#LP:")) // Loop back to set point in dialogue (note LP == Loop)
        {
            int NewLoop = System.Convert.ToInt16(DialogueValue.Remove(0, 4));
            StartingDialoguePath = NewLoop;
            DialoguePath++;
        }

        else if (DialogueValue.Contains("#PS:")) // Use the audio manager to play a sound (Put sound Index number after : ) (Note PS == Play Sound)
        {
            int SoundIndexNo = System.Convert.ToInt16(DialogueValue.Remove(0, 4));
            // Audiomanager.playsound(SoundIndexNo) ++++++++++++++++++++++++++++++++++++++++++++++++++++++ (Add stuff here when audio manager added) +++++++++++++++++++++++++
            Debug.Log("Play Sound: " + SoundIndexNo);
            DialoguePath++;
        }

        else if (DialogueValue.Contains("#Switch")) // Used to switch between player and NPC dialogue
        {
            PlayerTalking = !PlayerTalking;
            Debug.Log("Switch Speaker");
            CurrentNPCDialoguePath++;
        }

        else
        {

            PrintDialogue();
        }
    }

    public void PrintDialogue()
    {
        Debug.Log("Print Dialogue");
        if (PlayerTalking)
        {
            if (PrintSentenceInOneGo)
            {
                PrintFullSentencePlayer();
            }
            else
            {
                TypewriterPrintPlayer();
            }
        }
        else
        {
            if (PrintSentenceInOneGo)
            {
                PrintFullSentenceNPC();
            }
            else
            {
                TypewriterPrintNPC();
            }
        }
    }

    public void PrintFullSentencePlayer()
    {
        Debug.Log("Print Full Sentence Player");
        // Prints the full line of dialogue in one go
        DialogueBox.text = PlayerDialogue[DialoguePath];
    }

    IEnumerator TypewriterPrintPlayer() // Runs through each character individually and prints them with a pause between each one
    {
        Debug.Log("Typewriter print Player");
        for (int CharNo = 0; CharNo < (PlayerDialogue[DialoguePath].Length + 1); CharNo++)
        {
            DialogueBox.text = PlayerDialogue[DialoguePath].Substring(0, CharNo);
            
                yield return new WaitForSeconds(CoroutineDelay); // Wait can be edited in inspector, suggested delay is 0.03f
            
        }

        CoroutineStarted = false;
        EndOfSentence = true;
    }

    public void PrintFullSentenceNPC()
    {
        Debug.Log("Print Full Sentence NPC");
        // Prints the full line of dialogue in one go
        DialogueBox.text = NPCDialogueScrpt.NPCDialogue[DialoguePath];
    }

    IEnumerator TypewriterPrintNPC() // Runs through each character individually and prints them with a pause between each one
    {
        Debug.Log("Typewriter print NPC");
        for (int CharNo = 0; CharNo < (NPCDialogueScrpt.NPCDialogue[DialoguePath].Length + 1); CharNo++)
        {
            DialogueBox.text = NPCDialogueScrpt.NPCDialogue[DialoguePath].Substring(0, CharNo);

            yield return new WaitForSeconds(CoroutineDelay);

        }

        CoroutineStarted = false;
        EndOfSentence = true;
    }

    public void EndOfDialogueBlock()
    {
        Debug.Log("End of dialogue");
        LastDialoguePath = DialoguePath;
        Interacting = false;
        DialogueBox.text = "";
    }

    public void BreakInDialogue()
    {
        Debug.Log("Break In Dialogue");
        LastDialoguePath = DialoguePath;
        Interacting = false;
        NewConversation = true;
        DialogueBox.text = "";
    }
}
