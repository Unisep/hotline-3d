using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour
{
	private Vector3 posInicial;
	public AudioClip hit;
	public AudioClip empty;

	void Start ()
	{
		this.posInicial = transform.position;
	}

	void Update ()
	{
		float dist = Vector3.Distance (transform.position, posInicial);
	
		if (dist > 50)
			Destroy (gameObject);
	}

	public void semBalas ()
	{
		AudioSource.PlayClipAtPoint (empty, transform.position);
	}
}
