using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    float hMove;
    Vector2 dir;

    [SerializeField] float speed = 10;
    [SerializeField] float jump = 7.5f;

    Rigidbody2D rb;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlayer();
        JumpingPlayer();
    }

    void MovingPlayer()
    {
        hMove = Input.GetAxis("Horizontal");
        dir = new Vector2(hMove, 0);
        transform.Translate(dir * Time.deltaTime * speed);
    }

    void JumpingPlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = new Vector2(0, 1) * jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
