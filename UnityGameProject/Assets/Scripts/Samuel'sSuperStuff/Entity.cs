using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float MovementSpeed;
    public float WalkSpeed = 2;
    public float SprintSpeed = 4;
    private float Stamina = 5.0f;

    public float JumpStrength;
   
    private Rigidbody Rigid;

    Animator anim; //Assigns the animator

    private bool StartRotate = true;

    private bool Moving;

    //set to one for no effect and only changed in traps;
    public float SpeedModifier = 1;       
    
    protected virtual void Start ()
    {
        MovementSpeed = WalkSpeed;
        anim = GetComponent<Animator>(); //Calls animator
        Rigid = GetComponent<Rigidbody>();        
	}	
	
    public void Move(Vector3 MoveDir)
    {        
         if (Input.GetKey(KeyCode.W))
         {
              Moving = true;

              anim.SetBool("IsWalking", true);

              Vector3 Vec;
              Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);

              Rigid.velocity = Vec * SpeedModifier;

              if (Input.GetKey(KeyCode.LeftShift))
              {
                    MovementSpeed = SprintSpeed;

                     anim.SetBool("IsRunning", true);

                    //Vector3 Vec;
                    //Vec = new Vector3(MoveDir.x * SprintSpeed, Rigid.velocity.y, MoveDir.z * SprintSpeed);
                    //
                    //Rigid.velocity = Vec * SpeedModifier;
              }
              else
              {
                    anim.SetBool("IsRunning", false);
                    MovementSpeed = WalkSpeed;
              }

              if (Input.GetKey(KeyCode.A))
              {
                 MovementSpeed = WalkSpeed;

                anim.SetBool("IsWalking", false);
                anim.SetBool("IsWalkingL", true);
              
                  
              }
              else
              {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsWalkingL", false);
              }

            if (Input.GetKey(KeyCode.D))
            {
                MovementSpeed = WalkSpeed;

                anim.SetBool("IsWalking", false);
                anim.SetBool("IsWalkingR", true);


            }
            else
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsWalkingR", false);
            }
        }
        

        //if(Input.GetKey(KeyCode.Space))
        // {
        //     anim.SetBool("IsJumping", true);
        //     Jump();
        // }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }
    }

    public void Jump()
    {
       if (OnGround())
       {
            Rigid.AddForce(Vector3.up * JumpStrength);
       }
    }


    public bool OnGround()
    {
        RaycastHit HitInfo;
        return Physics.Raycast(transform.position, Vector3.down, out HitInfo, 1.2f);

    }

    public float GetSpeed()
    {
        return WalkSpeed;
    }

    

    

}
