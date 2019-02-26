using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Locked;
    public bool DoorOpen;

    public void OpenDoor()
    {
        if (Locked)
        {
            Debug.Log("The door is locked");
        }
        else
        {
            if (DoorOpen)
            {
                DoorOpen = false;
				// Play closing animation

				// -- Jonathan Addition Start --
				if (GetComponentInChildren<Animator>())
				{
					foreach (Animator A in GetComponentsInChildren<Animator>())
					{
						A.SetTrigger("DoorClosed");
					}
				}
				// -- Jonathan Addition End --

				Debug.Log("Door is Open, closing door");
            }
            else
            {
                DoorOpen = true;

				// -- Jonathan Addition Start --
				if (GetComponentInChildren<Animator>())
				{
					foreach (Animator A in GetComponentsInChildren<Animator>())
					{
						A.SetTrigger("DoorOpened");
					}
				}
				// -- Jonathan Addition End --

				// Play Opening animation
				Debug.Log("Door is closed, opening door");
            }
        }

    }


	// -- Jonathan Addition Start --
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			OpenDoor();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			OpenDoor();
		}
	}
	// -- Jonathan Addition End --
}
