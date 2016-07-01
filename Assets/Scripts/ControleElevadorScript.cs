using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControleElevadorScript : MonoBehaviour
{
	private bool CanOpen;
	private bool Open;
	private AudioSource sound;

	public Animator anim;

	void Start ()
	{
		CanOpen = false;
		Open = false;
		sound = GetComponent<AudioSource> ();

		CloseTheDoors (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E) && CanOpen) {
			if (GameControllerScript.state == GameState.GameFinished && Open) {
				CloseTheDoors ();

				GameControllerScript.state = GameState.GameSetup;
				SceneManager.LoadScene ("WinnerMenu");
			}

			if (!Open)
				OpenTheDoors ();
			else
				CloseTheDoors ();
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			if (GameControllerScript.state == GameState.GameSetup ||
			    GameControllerScript.state == GameState.GameFinished) {

				CanOpen = true;
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.CompareTag ("Player"))
			CanOpen = false;
	}

	public void OpenTheDoors ()
	{
		sound.Play ();

		anim.SetBool ("Abrindo", true);
		anim.SetBool ("Fechando", false);
		Open = true;
	}

	public void CloseTheDoors (bool play = true)
	{
		if (play)
			sound.Play ();
		
		anim.SetBool ("Abrindo", false);
		anim.SetBool ("Fechando", true);
		Open = false;
	}
}