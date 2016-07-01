using UnityEngine;
using System.Collections;

public class VidaScript : MonoBehaviour
{
	public int poderKit = 10;

	private AudioSource source;

	void Start ()
	{
		this.source = GetComponent<AudioSource> ();
	}

	void Update ()
	{
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			// ver sobre o volume
			source.Play ();

			ControladorVidaScript vida = col.gameObject.GetComponent<ControladorVidaScript> ();
			vida.recuperarVida (this.poderKit);

			Destroy (gameObject);
		}
	}
}
