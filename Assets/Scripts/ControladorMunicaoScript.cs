using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorMunicaoScript : MonoBehaviour
{
	public int totalBalas = 20;
	private int atualBalas;

	public Text mostrador;

	void Start ()
	{
		this.atualBalas = this.totalBalas;

		atualizarMostrador ();
	}

	public void atirar ()
	{
		atualBalas--;

		atualizarMostrador ();
	}

	public void recarregar (int novoCartucho)
	{
		atualBalas += novoCartucho;

		atualizarMostrador ();
	}

	public bool temBalas ()
	{
		return atualBalas >= 1;
	}

	private void atualizarMostrador ()
	{
		if (mostrador == null)
			return;
		
		mostrador.text = "AMMO: " + atualBalas.ToString ();
	}
}
