using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Start : MonoBehaviour
{
    public bool Event;
    public GameObject Player;
    public PlayerController MovementScript;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Event == true)
        {

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("running");
            MovementScript.enabled = false;
            Event = true;

        if(MovementScript == false)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsWalkingL", false);
                anim.SetBool("IsWalkingR", false);
                anim.SetBool("IsRunning", false);
            }
            
        }
    }
}
