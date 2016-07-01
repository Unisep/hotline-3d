using UnityEngine;
using System.Collections;

public class VidaScript : MonoBehaviour
{
	public int poderKit = 10;
	public AudioClip pickUp;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (pickUp, col.gameObject.transform.position);

			ControladorVidaScript vida = col.gameObject.GetComponent<ControladorVidaScript> ();
			vida.recuperarVida (this.poderKit);

			Destroy (gameObject);
		}
	}
}