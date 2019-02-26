using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Locked;
    public bool DoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
                DoorOpen = false;
                // Play closing animation
                Debug.Log("Door is Open, closing door");
            }
            else
            {
                DoorOpen = true;
                // Play Opening animation
                Debug.Log("Door is closed, opening door");
            }
        }

    }
}
