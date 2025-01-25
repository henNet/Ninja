using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikensMove : MonoBehaviour {
	//=  +
	public float velocidade = 5.5f; 
	public float rotacao;
	private float limiteX = 8.2f;
	private Vector3 posicaoInicial;

	int pontosNinja;

	// Use this for initialization
	void Start () {
		posicaoInicial = this.transform.position;
		rotacao = Random.Range(-360, -360);
	}
	
	// Update is called once per frame
	void Update () {
		
		pontosNinja = GameObject.FindGameObjectWithTag ("ninja").GetComponent<NinjaMove>().pontos + 10;
		float deslocamento = velocidade * Time.deltaTime * pontosNinja/10;
	

		this.transform.position = new Vector3 (
			this.transform.position.x + deslocamento,
			this.transform.position.y,
			this.transform.position.z);

		transform.Rotate(new Vector3 (0, 0, rotacao)*Time.deltaTime );

		if (this.transform.position.x > limiteX || this.transform.position.x <-limiteX) {
			resetaPosicao ();
		}
	}

	public void resetaPosicao()
	{
		this.transform.position = posicaoInicial;
		//velocidade = Random.Range (2.0f, 6.0f);
		//rotacao = Random.Range(-90, -180);
	}
}
