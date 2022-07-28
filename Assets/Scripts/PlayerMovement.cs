using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2;
    [SerializeField] private LayerMask blockingLayer;

    private Transform playerPos;
    private PolygonCollider2D playerCollider;
    private int horizontal;
    private float xDir;

    void Awake()
    {
        playerPos = GetComponent<Transform>();
        playerCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        MovementPlatform();
    }

    private void MovementPlatform()
    {
        horizontal = (int) Input.GetAxisRaw("Horizontal");
        xDir = playerSpeed * horizontal * Time.deltaTime;
        if (!IsHitWall(horizontal))
            playerPos.transform.Translate(new Vector3(xDir, 0, 0));
    }

    private bool IsHitWall(float xDir)
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
}