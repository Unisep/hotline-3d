using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player") &&
		    GameControllerScript.state == GameState.GameSetup) {

			GameControllerScript.state = GameState.GameInitiated;

			var door = GameObject.FindGameObjectWithTag ("ElevatorDoor").GetComponent<ControleElevadorScript> ();
			door.CloseTheDoors ();
		}
	}
}
