using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 2;
    private Rigidbody2D ballBody;
    private int jump;

    void Awake()
    {
        ballBody = GetComponent<Rigidbody2D>();
        ballBody.AddForce(-transform.up * ballSpeed);
    }

    void FixedUpdate()
    {
        MovementBall();
    }

    private void MovementBall()
    {
        jump = (int) Input.GetAxisRaw("Vertical");
        if (jump > 0)
        {
            gameObject.transform.position = new Vector3(0, -3.8f, 0);
        }
    }
}