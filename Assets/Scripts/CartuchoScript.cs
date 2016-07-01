using UnityEngine;
using System.Collections;

public class CartuchoScript : MonoBehaviour
{
	public int pente = 5;

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

			ControladorMunicaoScript municao = col.gameObject.GetComponent<ControladorMunicaoScript> ();
			municao.recarregar (this.pente);

			Destroy (gameObject);
		}
	}
}
