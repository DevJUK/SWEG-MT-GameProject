using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBGScript : MonoBehaviour
{

	private InventoryScript InvScript;

	private void Start()
	{
		InvScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
	}

	public void ClosePanel()
	{
		InvScript.PanelOpen = false;
	}

}
