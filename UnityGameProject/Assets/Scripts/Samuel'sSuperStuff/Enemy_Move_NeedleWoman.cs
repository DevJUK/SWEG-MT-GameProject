using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Move_NeedleWoman : MonoBehaviour
{
    public GameObject Player;   //sets object to follow

    NavMeshAgent enemy; //Assigns the nav mesh

    Animator anim; //Assigns the animator

    public bool PlayerInRoom;

    private int AmountOfStabs;

   // public float RayLength;
    private float TimeLeft = 3.0f;

    void Start()
    {
        anim = GetComponent<Animator>(); //Calls animator
        enemy = GetComponent<NavMeshAgent>(); //Calls nav mesh
    }

    void Update()
    {
            if ((Player) && (PlayerInRoom))
            {
                if (enemy.remainingDistance != Mathf.Infinity && enemy.remainingDistance >= enemy.stoppingDistance)
                {
                    enemy.destination = Player.transform.position;
                    anim.SetBool("Running", true);
                    anim.SetBool("Stab", false);
                }

                else if (enemy.remainingDistance != Mathf.Infinity && enemy.remainingDistance < enemy.stoppingDistance)
                {
                    if (AmountOfStabs == 2)
                    {
                        anim.SetBool("Running", false);
                        anim.SetBool("Stab", false);
                    }
                    else
                    {
                        enemy.destination = Player.transform.position;
                        anim.SetBool("Running", false);
                        anim.SetBool("Stab", true);
                    AmountOfStabs++;
                    }
                }
            }
            else
            {
                anim.SetBool("Running", false);
                anim.SetBool("Stab", false);
            Debug.Log("Go to idle");
            }
    }
}
