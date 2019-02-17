using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Start : MonoBehaviour
{
    public bool Event;
    public GameObject Player;
    public PlayerController MovementScript;    
    public Enemy_Move AIMovment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Event == true)
        {
            AIMovment.enabled = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("running");
            MovementScript.enabled = false;
            Event = true;
        }        
    }
}
