using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTriggerOff : MonoBehaviour
{
    public GameObject TriggerBox;
    public Event_Start Boolon;
    public PlayerController MovementScript;

    private void Update()
    {
        StartCoroutine(BoxOff());
    }

    IEnumerator BoxOff()
    {
       
        if (Boolon.Event == true)
        {
            yield return new WaitForSeconds(10);
            TriggerBox.SetActive(false);           
            MovementScript.enabled = true;
            
        }

    }
}
