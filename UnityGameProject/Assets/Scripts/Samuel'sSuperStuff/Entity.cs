using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{    
    public float MovementSpeed;   

    public float JumpStrength;
   
    private Rigidbody Rigid;   

    private bool StartRotate = true;

    //set to one for no effect and only changed in traps;
    public float SpeedModifier = 1;       
    
    protected virtual void Start ()
    {
        Rigid = GetComponent<Rigidbody>();        
	}	
	
    public void Move(Vector3 MoveDir)
    {
        Vector3 Vec;
        Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
       
        Rigid.velocity = Vec * SpeedModifier;
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
        return MovementSpeed;
    }

    

    

}
