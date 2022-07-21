using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        ReturnToPool();
    }
    
    public void ReturnToPool () {
        gameObject.SetActive (false);
    }

}
