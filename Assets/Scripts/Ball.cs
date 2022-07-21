using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action OnBollCollider;
    [SerializeField] private Rigidbody2D ballBody;
    [SerializeField]private float ballSpeed = 0.1f;

    void Start () {
        ballBody = GetComponent<Rigidbody2D>();
        ballBody.AddForce(-transform.up * ballSpeed);
    }
    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.TryGetComponent(out Block block))
        {
            OnBollCollider?.Invoke();
        }
     
    }
    private void FixUpdate()
    {
        int jump;
        jump = (int)Input.GetAxisRaw("Vertical");
        if (jump > 0)
        {
            gameObject.transform.position = new Vector3(0, -0.1f, 0);
        }
    }
}
