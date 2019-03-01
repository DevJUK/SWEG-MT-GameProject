using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBGScript : MonoBehaviour
{
	public Item ThisItem;
	private InventoryScript InvScript;
	private ThrowableItemScript ThrowScript;

	private void Start()
	{
		InvScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
		ThrowScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ThrowableItemScript>();
	}

	public void ClosePanel()
	{
		InvScript.PanelOpen = false;
	}

	public void EquipItem()
	{
		if (ThrowScript.ItemHeld == null)
		{
			ThrowScript.ItemHeld = ThisItem.gameObject;
			ThisItem.RemoveItemFromInv();
			InvScript.gameObject.GetComponentInParent<InvButtonScript>().Inv.SetActive(false);
			InvScript.gameObject.GetComponentInParent<InvButtonScript>().OpenInv();
		}
	}

}
