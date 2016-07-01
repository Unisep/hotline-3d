using UnityEngine;
using System.Collections;

public class CartuchoScript : MonoBehaviour
{
	public int pente = 5;

	public AudioClip pickUp;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (pickUp, col.gameObject.transform.position);

			ControladorMunicaoScript municao = col.gameObject.GetComponent<ControladorMunicaoScript> ();
			municao.recarregar (this.pente);

			Destroy (gameObject);
		}
	}
}
