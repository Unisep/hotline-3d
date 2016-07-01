using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour
{
	private Vector3 posInicial;
	public AudioClip hit;
	public AudioClip empty;

	private AudioSource source;

	void Start ()
	{
		this.source = GetComponent<AudioSource> ();
		this.source.clip = hit;

		this.posInicial = transform.position;
	}

	void Update ()
	{
		float dist = Vector3.Distance (transform.position, posInicial);
	
		if (dist > 50) {
			if (this.source.clip != hit)
				this.source.clip = hit;
			
			source.Play ();

			Destroy (gameObject);
		}
	}

	public void semBalas ()
	{
		this.source = GetComponent<AudioSource> ();

		this.source.clip = empty;
		this.source.Play ();
	}
}

/*
using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	private Vector3 posInicial;
	public sourceSource[] audios;

	void Start () {
		this.posInicial = transform.position;
	}

	void Update () {
		float dist = Vector3.Distance(transform.position, posInicial);

		if (dist > 50) {
			audios[0].Play();

			Destroy(gameObject);
		}
	}

	public void semBalas(){
		audios[1].Play();
	}
}
*/