using UnityEngine;
using System.Collections;

public class InimigoScript : MonoBehaviour
{
	enum EstadoInimigo
	{
		PARADO,
		ATIRANDO,
		PERSEGUINDO
	}

	private ControladorVidaScript vida;
	private GameObject player;
	private EstadoInimigo estadoAtual;

	private float distancia;
	private NavMeshAgent agent;

	private float timerTiro;

	public GameObject prefabBala;
	public GameObject prefabMunicao;
	public GameObject prefabVida;

	public Transform mira;

	void Start ()
	{
		this.vida = GetComponent<ControladorVidaScript> ();
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.estadoAtual = EstadoInimigo.PARADO; 
		this.agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		distancia = Vector3.Distance (transform.position, player.transform.position);

		if (estadoAtual == EstadoInimigo.PARADO) {
			updateParado ();
		} else if (estadoAtual == EstadoInimigo.PERSEGUINDO) {
			updatePerseguindo ();
		} else {
			updateAtirando ();
		}
	}

	private void updateParado ()
	{
		
		if (distancia < 30) {
			RaycastHit hit;
			bool raycastOk = Physics.Linecast (transform.position, player.transform.position, out hit);

			if (raycastOk) {
				if (hit.collider.gameObject.CompareTag ("Player")) {
					this.estadoAtual = EstadoInimigo.PERSEGUINDO;
				}
			}
		}
	}

	private void updatePerseguindo ()
	{
		agent.SetDestination (player.transform.position);
		transform.LookAt (player.transform.position);

		if (distancia < 15) {
			this.timerTiro = 0f;
			this.estadoAtual = EstadoInimigo.ATIRANDO;

		} else if (distancia > 30) {
			this.estadoAtual = EstadoInimigo.PARADO;
		}
	}

	private void updateAtirando ()
	{
		agent.SetDestination (player.transform.position);
		transform.LookAt (player.transform.position);

		if (distancia > 15) {
			this.estadoAtual = EstadoInimigo.PERSEGUINDO;
		} else {
			this.timerTiro += Time.deltaTime;

			if (timerTiro > 0.5) {
				timerTiro = 0f;

				GameObject bala = (GameObject)Instantiate (prefabBala, mira.position, transform.rotation);

				Rigidbody body = bala.GetComponent<Rigidbody> ();
				body.velocity = bala.transform.TransformDirection (Vector3.forward * 50);
			}
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("PlayerBullet")) {
			vida.levouTiro ();
			Destroy (col.gameObject);

			if (vida.morto ()) {
				Vector3 pos = transform.position;
				pos.y -= 0.9f;

				Instantiate ((Random.value > 0.5 ? prefabVida : prefabMunicao), pos, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
