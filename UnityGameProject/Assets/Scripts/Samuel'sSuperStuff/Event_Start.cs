using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Start : MonoBehaviour
{
    public bool Event;
    //public GameObject Player;
    public PlayerController MovementScript;
    public Mouse_Move stopMouse;
    public Enemy_Move AIMovment;
    //public Entity AnimStop;
    //public Event_Start Boolon;
    Animator anim; //Assigns the animator
    public FlyingPans PansMove;
    public FlyingPans PansMove2;
    public FlyingPans PansMove3;
    public FlyingPans PansMove4;
    public FlyingPans PansMove5;
    public FlyingPans PansMove6;
    public FlyingPans PansMove7;
    public FlyingPans PansMove8;
    public FlyingPans PansMove9;
    public FlyingPans PansMove10;
    public FlyingPans PansMove11;
    public FlyingPans PansMove12;


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
            stopMouse.enabled = false;
            PansMove.enabled = true;
            PansMove2.enabled = true;
            PansMove3.enabled = true;
            PansMove4.enabled = true;
            PansMove5.enabled = true;
            PansMove6.enabled = true;
            PansMove7.enabled = true;
            PansMove8.enabled = true;
            PansMove9.enabled = true;
            PansMove10.enabled = true;
            PansMove11.enabled = true;
            PansMove12.enabled = true;
            Event = true;
        }        
    }
}
