using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseScript : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			SceneManager.LoadSceneAsync("GroundFloorScene");
		}
	}
}
