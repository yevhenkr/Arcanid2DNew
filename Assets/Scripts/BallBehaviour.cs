using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float ballSpeed = 2;

    private Rigidbody2D ballBody;


    void Awake()
    {
        ballBody = GetComponent<Rigidbody2D>();
        ballBody.AddForce(-transform.up * ballSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        int jump;

        jump = (int) Input.GetAxisRaw("Vertical");
        if (jump > 0)
        {
            gameObject.transform.position = new Vector3(0, -3.8f, 0);
        }
    }
}