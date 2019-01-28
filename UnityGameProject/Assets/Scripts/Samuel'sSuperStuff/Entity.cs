using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{    
    public float WalkSpeed;
    public float SprintSpeed;

    public float JumpStrength;
   
    private Rigidbody Rigid;

    Animator anim; //Assigns the animator

    private bool StartRotate = true;

    private bool Moving;

    //set to one for no effect and only changed in traps;
    public float SpeedModifier = 1;       
    
    protected virtual void Start ()
    {
        anim = GetComponent<Animator>(); //Calls animator
        Rigid = GetComponent<Rigidbody>();        
	}	
	
    public void Move(Vector3 MoveDir)
    {
        //if (Input.GetKey(Key:))
        //{
            if (Input.GetKey(KeyCode.W))
            {
                Moving = true;

                anim.SetBool("IsWalking", true);

                Vector3 Vec;
                Vec = new Vector3(MoveDir.x * WalkSpeed, Rigid.velocity.y, MoveDir.z * WalkSpeed);

                Rigid.velocity = Vec * SpeedModifier;
            }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    Moving = true;
        //
        //    anim.SetBool("IsWalkingL", true);
        //
        //    Vector3 Vec;
        //    Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
        //
        //    Rigid.velocity = Vec * SpeedModifier;
        //}
        //// else if (Input.GetKey(KeyCode.S))
        //// {
        ////     Moving = true;
        ////
        ////     anim.SetBool("IsWalking", true);
        ////
        ////     Vector3 Vec;
        ////     Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
        ////
        ////     Rigid.velocity = Vec * SpeedModifier;
        //// }
        //if (Input.GetKey(KeyCode.D))
        //{
        //    Moving = true;
        //
        //    anim.SetBool("IsWalkingR", true);
        //
        //    Vector3 Vec;
        //    Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
        //
        //    Rigid.velocity = Vec * SpeedModifier;
        //}
        //} //
       // if (Input.GetKey(KeyCode.LeftShift))
       // {
       //     WalkSpeed = SprintSpeed;
       //     
       //
       //    anim.SetBool("IsRunning", true);
       //
       //     //Vector3 Vec;
       //     //Vec = new Vector3(MoveDir.x * SprintSpeed, Rigid.velocity.y, MoveDir.z * SprintSpeed);
       //     //
       //     //Rigid.velocity = Vec * SpeedModifier;
       // }
      //if(Input.GetKey(KeyCode.Space))
      // {
      //     anim.SetBool("IsJumping", true);
      //     Jump();
      // }
        else
        {
            anim.SetBool("IsWalking", false);
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
