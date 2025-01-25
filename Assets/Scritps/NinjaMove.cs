using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaMove : MonoBehaviour
{

	public float deslocamento = 0.5f;
	private float limiteY = 3.41f;
	private Vector3 posicaoInicial;

	public Text uiPontuacao;
	public int pontos = 0;
	public Text uiVidas;
	private int vidas = 5;
	public Image uiGameOver;
	public Button uiNewGame;
	public GameObject deathEffect;
	public AudioSource deathSoundEffect;
	public AudioSource winSoundEffect;

	// Use this for initialization
	void Start()
	{
		posicaoInicial = this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.UpArrow) && vidas > 0)
		{
			this.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y + deslocamento,
				this.transform.position.z);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow) &&
				vidas > 0 && transform.position != posicaoInicial)
		{
			this.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y - deslocamento,
				this.transform.position.z);
		}

		if (this.transform.position.y > limiteY)
		{
			resetaPosicao();
			ganharPontos();
			winSoundEffect.Play();
		}

		if (vidas == 0)
		{
			uiGameOver.gameObject.SetActive(true);
			uiNewGame.gameObject.SetActive(true);
		}
	}

	public void clickArrowBtn(float value)
	{
		if (transform.position == posicaoInicial && value < 0) return;

		this.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y + value,
				this.transform.position.z);
	}

	public void resetaPosicao()
	{
		this.transform.position = posicaoInicial;
	}

	void OnTriggerEnter2D(Collider2D objet)
	{
		Destroy(Instantiate(deathEffect, transform.position, transform.rotation), 0.5f);
		deathSoundEffect.Play();
		resetaPosicao();
		perderVida();
	}

	void ganharPontos()
	{
		pontos = pontos + 10;
		uiPontuacao.text = "Pontos: " + pontos.ToString();
	}

	void perderVida()
	{
		vidas--;
		uiVidas.text = "Vidas: " + vidas.ToString();
	}

	public void resetarJogo()
	{
		pontos = 0;
		vidas = 5;
		uiPontuacao.text = "Pontos: " + pontos.ToString();
		uiVidas.text = "Vidas: " + vidas.ToString();
		uiGameOver.gameObject.SetActive(false);
		uiNewGame.gameObject.SetActive(false);
	}
}
