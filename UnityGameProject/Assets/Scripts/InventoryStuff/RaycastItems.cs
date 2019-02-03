using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastItems : MonoBehaviour
{
	public float Range;
	public GameObject UI;
	private bool UIOpen;

	private PickupUIText PickupScript;


	private void Start()
	{
		PickupScript = GameObject.Find("PickupPopup").GetComponent<PickupUIText>();

		InRangeUI();
	}


	private void FixedUpdate()
	{
		RaycastHit Hit;

		if (Physics.Raycast(transform.position, transform.forward, out Hit, Range))
		{
			if (Input.GetButtonDown("Pickup"))
			{
				AddHitToInv(Hit);
			}

			if (Hit.transform.gameObject.GetComponent<Item>())
			{
				PickupScript.SetText(Hit.transform.gameObject.GetComponent<Item>().ItemName);
			}

			UIOpen = true;
		}
		else
		{
			UIOpen = false;
		}

		InRangeUI();
	}



	private void AddHitToInv(RaycastHit Hit)
	{
		if (Hit.transform.gameObject.GetComponent<Item>())
		{
			Hit.transform.gameObject.GetComponent<Item>().AddToInv(Hit.transform.gameObject.GetComponent<Item>());
		}
	}


	private void InRangeUI()
	{
		if (UIOpen)
		{
			UI.SetActive(true);
		}

		if (!UIOpen)
		{
			UI.SetActive(false);
		}
	}
}
