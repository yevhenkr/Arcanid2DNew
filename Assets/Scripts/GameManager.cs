using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool gameOver = false;

    public GameObject ball;
   // public Text scoreText;
   // public Text gameOverText;

    private BoardManager boardScript;

    public void TakeScore(int addScore)
    {
        score += addScore;
    }

    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
    }

    private void GameStuff()
    {
       // scoreText.text = "Score : " + score;
        if (ball.transform.position.y < -5)
        {
            Destroy(ball);
            //gameOverText.text = "You Lost The Ball";
            gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            GameStuff();
            boardScript.CheckGameOver();
        }
    }
}
