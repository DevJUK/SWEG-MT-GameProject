using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
	public GameObject Player;
	public SnakeBiteEvent BiteEventScript;

	private void Start()
	{
		BiteEventScript = GameObject.Find("EventTrigger-RoomE").GetComponent<SnakeBiteEvent>();
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			BiteEventScript.MoveSnake = false;
			Player.GetComponentInChildren<Stats>().Health = 9;
			Player.GetComponentInChildren<PlayerController>().enabled = true;
			gameObject.SetActive(false);
		}
	}
}
