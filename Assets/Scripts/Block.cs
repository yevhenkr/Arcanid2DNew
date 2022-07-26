using UnityEngine;

public class Block : MonoBehaviour
{
    private int HealthValue { get; set; }

    public void SetHealthValue(int health)
    {
        HealthValue = health;
    }
    public void SetSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}