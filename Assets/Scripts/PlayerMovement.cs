using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public LayerMask blockingLayer;

    private Transform playerPos;
    private PolygonCollider2D playerCollider;


    void Awake()
    {
        playerPos = GetComponent<Transform>();
        playerCollider = GetComponent<PolygonCollider2D>();
    }


    private bool HitWall(float xDir)
    {
        Vector2 start = playerPos.transform.position;
        Vector2 end = start + new Vector2(xDir, 0);
        RaycastHit2D hit;

        playerCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        playerCollider.enabled = true;
        if (hit.transform == null)
            return false;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        int horizontal;
        float xDir;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        xDir = playerSpeed * horizontal * Time.deltaTime;
        if (!HitWall(horizontal))
            playerPos.transform.Translate(new Vector3(xDir, 0, 0));
    }
}