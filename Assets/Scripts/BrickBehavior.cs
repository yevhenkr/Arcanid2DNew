using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
	public 	int 	hitPoints = 2;
	public	Sprite 	dmgSprite;

	// public	GameObject 		gameManagerObject;
	public	GameManager		gameScript;

	private bool 	isHit = false;

	private SpriteRenderer 		spriteRenderer;

	void 	OnTriggerExit2D(Collider2D other)
	{
		hitPoints--;
		spriteRenderer.sprite = dmgSprite;
		Color   darkerColor = new Color ((spriteRenderer.color.r * 0.8f), (spriteRenderer.color.g * 0.8f), (spriteRenderer.color.b * 0.8f));

		spriteRenderer.color = darkerColor;
		isHit = true;
	}

	void Awake()
	{
		// gameScript = gameManagerObject.GetComponent<GameManager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	public int	ScoreStuff()
	{
		int score = 0;

		if (isHit)
		{
			isHit = false;
			score += 10;
		}
		if (hitPoints <= 0)
		{
			gameObject.SetActive(false);
			score += 100;
		}
		return score;
	}


	void Update()
	{
//		gameScript.TakeScore(ScoreStuff());
	}
}
