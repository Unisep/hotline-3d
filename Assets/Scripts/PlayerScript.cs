using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public GameObject prefabBala;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	private Camera cam;
	private ControladorVidaScript vida;
	private ControladorMunicaoScript municao;
	private bool damaged = false;

	void Start ()
	{
		this.cam = Camera.main;

		this.vida = GetComponent<ControladorVidaScript> ();
		this.municao = GetComponent<ControladorMunicaoScript> ();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			if (municao.temBalas ()) {
				municao.atirar ();

				GameObject bala = (GameObject)Instantiate (prefabBala, cam.transform.position, cam.transform.rotation);

				Rigidbody body = bala.GetComponent<Rigidbody> ();
				body.velocity = bala.transform.TransformDirection (Vector3.forward * 50);
			} else {
				((GameObject)prefabBala).GetComponent<BalaScript> ().semBalas ();
			}
		}

		if (damaged) {
			vida.levouTiro ();
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("EnemyBullet")) {
			damaged = true;
			Destroy (col.gameObject);

			if (vida.morto ()) {
				GameControllerScript.state = GameState.GameSetup;
				SceneManager.LoadScene ("DiedMenu");
			}
		} 
	}
}
