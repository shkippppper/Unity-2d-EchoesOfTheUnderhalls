using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    
    private BoxCollider2D bc2D;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private PlayerShooting playerShooting;

    private Vector3 moveDir;
    private Vector3 rollDir;

    [Header("Movement")]
    public float moveSpeed = 1f;
    
    [Header("Dashing")]
    public float dashSpeed = 5f;
    public float dashDistance = 2f;
    public float dashCooldown = 1f;
    private bool canDash = true;
    

    public Color flashColor = new Color(1f, 1f, 1f, 0.5f);
    private Color originalColor;
    public bool dashCreatesSpecialOnStart = false;
    public bool dashCreatesSpecialOnEnd = false;



    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerShooting = GetComponent<PlayerShooting>();

    }

    private void Start()
    {
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {

        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveDir.x, moveDir.y).normalized;

        rollDir = moveDir;

        //rotation
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the mouse is to the right of the player
        if (mousePos.x > transform.position.x)
        {
            // Flip the player to face right
            transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }
        // Check if the mouse is to the left of the player
        else if (mousePos.x < transform.position.x)
        {
            // Flip the player to face left
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
        }

        if (rollDir == Vector3.zero)
        {
            Vector3 mouse = new Vector3(mousePos.x, mousePos.y, 0);
            rollDir = (mouse - transform.position).normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

    }


    private void FixedUpdate()
    {
        rb2D.velocity = moveDir * moveSpeed;
    }


    IEnumerator Dash()
    {
        canDash = false;

        //dash already started, adding force to player to dash, making player flash and disabling collider.
        rb2D.AddForce(rollDir * 100f * dashSpeed);
        spriteRenderer.color = flashColor;
        bc2D.enabled = false;

        if (dashCreatesSpecialOnStart)
        {
            playerShooting.DashCreatesSpecial(transform.position);
        }


        yield return new WaitForSeconds(dashDistance / dashSpeed);
        
        //dash finished, stoping player, returning normaln color and enabling collider.
        rb2D.velocity = Vector2.zero;
        spriteRenderer.color = originalColor;
        bc2D.enabled = true;

        if (dashCreatesSpecialOnEnd)
        {
            playerShooting.DashCreatesSpecial(transform.position);
        }


        yield return new WaitForSeconds(dashCooldown);
        
        canDash = true;
    }
}
