using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class ClassroomCutsceneController : MonoBehaviour
{
	public PlayerController MovementScript;
	public PlayableDirector PD;
	public TimelineAsset Timeline;
	//public Camera Cam;
	private bool HasCutscenePlayed;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("running");
			PlayCutscene();
		}
	}


	private void PlayCutscene()
	{
		if (!HasCutscenePlayed)
		{
			//Cam.enabled = false;
			PD.Play();
			HasCutscenePlayed = true;
			MovementScript.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
			MovementScript.enabled = false;
			MovementScript.gameObject.GetComponent<Mouse_Move>().enabled = false;
		}
	}


	private void Update()
	{
		if (HasCutscenePlayed)
		{
			if (PD.state == PlayState.Paused)
			{
				MovementScript.enabled = true;
				MovementScript.gameObject.GetComponent<Mouse_Move>().enabled = true;
			}
		}
	}
}