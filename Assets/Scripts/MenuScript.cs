using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetButton ("Fire1") || Input.GetKeyDown (KeyCode.R)) {
			iniciar ();
		}
	}

	public void iniciar ()
	{
		SceneManager.LoadScene ("Cena");
	}
}