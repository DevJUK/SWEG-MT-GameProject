using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItemScript : MonoBehaviour
{
	public GameObject ItemHeld;

    // Update is called once per frame
    void Update()
    {
        if (ItemHeld != null)
		{
			ItemHeld.gameObject.transform.position = transform.position;
		}
    }


	public void ThrowItem(Item I)
	{
		I.gameObject.transform.SetParent(null);
		I.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward);
	}
}
