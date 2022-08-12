using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action EventDestroyBlock;
    public event Action<BlockData> BallData;
    [SerializeField] private float healthPoints;
    private Color color;
    private float maxHealth;

    private void Awake()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        healthPoints--;
        if (healthPoints <= 0)
        {
            ReturnToPool();
        }
        else
        {
            color.a = healthPoints / maxHealth;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void ReturnToPool()
    {
        EventDestroyBlock?.Invoke();
        color.a = 255;
        gameObject.SetActive(false);
    }

    public void SetHealthValue(int health)
    {
        healthPoints = health;
        maxHealth = healthPoints;
    }

    public void SetSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}