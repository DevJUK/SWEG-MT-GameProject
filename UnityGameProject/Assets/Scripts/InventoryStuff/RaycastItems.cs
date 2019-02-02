using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastItems : MonoBehaviour
{


	void Update()
	{
		RaycastHit Hit;

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(transform.position, transform.forward, out Hit, Mathf.Infinity))
			{
				Debug.DrawLine(transform.position, transform.forward, Color.yellow);
				Debug.Log(Hit.transform.gameObject);

				if (Hit.transform.gameObject.GetComponent<Item>())
				{
					Hit.transform.gameObject.GetComponent<Item>().AddToInv(Hit.transform.gameObject.GetComponent<Item>());
				}

			}
		}
	}
}
