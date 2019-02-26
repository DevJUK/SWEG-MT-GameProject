using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Locked;
    public bool DoorOpen;
	private bool Called;

	private void Update()
	{
		if (Input.GetButton("Pickup"))
		{
			Debug.Log("Test");

			if (!Called)
			{
				OpenDoor();
				Called = true;
			}
		}
	}


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

				// Play closing animation

				// -- Jonathan Addition Start --
				if (GetComponentInChildren<Animator>())
				{
					foreach (Animator A in GetComponentsInChildren<Animator>())
					{
						A.SetTrigger("DoorClosed");
					}

					DoorOpen = false;
				}
				// -- Jonathan Addition End --
				Debug.Log("Door is Open, closing door");
			}

			else
			{

				// -- Jonathan Addition Start --
				if (GetComponentInChildren<Animator>())
				{
					foreach (Animator A in GetComponentsInChildren<Animator>())
					{
						A.SetTrigger("DoorOpened");
					}

					DoorOpen = true;
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
		//if (other.gameObject.tag == "Player")
		//{
		//	OpenDoor();
		//}
		Called = false;
	}

	private void OnTriggerExit(Collider other)
	{
		//if (other.gameObject.tag == "Player")
		//{
		//	OpenDoor();
		//}
		Called = false;
	}
	// -- Jonathan Addition End --
}
