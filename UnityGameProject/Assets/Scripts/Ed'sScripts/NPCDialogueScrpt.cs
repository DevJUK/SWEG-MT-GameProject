using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScrpt : MonoBehaviour
{
    [Header("NPC ID")]
    [Tooltip("Unique number granted to each npc (must be set manually)")]
    public int NpcIDNumber;

    [Header("NPC Dialogue Lines")]
    [Tooltip("Put any dialogue you want the NPC to say in here, remember to use the in text triggers")]
    public List<string> NPCDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
