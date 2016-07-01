using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
	public static GameState state = GameState.GameSetup;
	public Text mostrador;

	private int leftEnemies;
	private int totalEnemies;

	void Start ()
	{
		findEnemies (ref totalEnemies);
		updateView ();
	}

	void Update ()
	{
		updateView ();

		if (!hasEnemies ()) {
			GameControllerScript.state = GameState.GameFinished;
		}
	}

	public void updateView ()
	{
		findEnemies (ref leftEnemies);
		mostrador.text = "LEFT: " + leftEnemies.ToString ("00") + "/" + totalEnemies.ToString ("00");
	}

	void findEnemies (ref int attribute)
	{
		attribute = GameObject.FindGameObjectsWithTag ("Inimigo").Length;
	}

	public bool hasEnemies ()
	{
		return GameObject.FindGameObjectsWithTag ("Inimigo").Length > 0;
	}

	// previnir própria bala matar o player.
	// colocar um objeto de "botão do elevador"
}
