using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerYBoudry;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void MovementAction()
    {
        float horizantalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizantalMove * moveSpeed, rb.velocity.y);
        SpriteFlip(horizantalMove);
    }
    void SpriteFlip(float horizantalMove)
    {
        if (horizantalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizantalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    void PlayerDestroy()
    {
        if(transform.position.y< playerYBoudry)
        {
            Destroy(gameObject);
            levelManager.ReSpawnPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroy();
    }

}
