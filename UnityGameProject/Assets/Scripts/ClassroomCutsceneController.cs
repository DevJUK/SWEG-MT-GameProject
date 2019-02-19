using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ClassroomCutsceneController : MonoBehaviour
{
	public PlayerController MovementScript;
	public PlayableDirector PD;
	public TimelineAsset Timeline;
	private bool HasCutscenePlayed;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("running");
			MovementScript.enabled = false;
			PlayCutscene();
		}
	}


	private void PlayCutscene()
	{
		if (!HasCutscenePlayed)
		{
			PD.Play();
			HasCutscenePlayed = true;
		}
	}
}