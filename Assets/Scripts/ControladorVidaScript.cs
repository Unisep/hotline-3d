using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorVidaScript : MonoBehaviour
{
	public int totalVida = 100;
	private int vidaCorrente;

	public Text mostrador;
	public Image mostradorImage;

	void Start ()
	{
		this.vidaCorrente = this.totalVida;

		atualizarMostrador ();
	}

	public void levouTiro ()
	{
		vidaCorrente -= 10;

		atualizarMostrador ();
	}

	public void recuperarVida (int quantidade)
	{
		vidaCorrente += quantidade;

		atualizarMostrador ();
	}

	public bool morto ()
	{
		return vidaCorrente <= 0;
	}

	public int getVidaCorrente ()
	{
		return vidaCorrente;
	}

	public void atualizarMostrador ()
	{
		if (this.mostrador != null)
			this.mostrador.text = "LIFE: " + vidaCorrente.ToString ();

		if (this.mostradorImage != null)
			this.mostradorImage.fillAmount = (float)vidaCorrente / (float)totalVida;
	}
}
