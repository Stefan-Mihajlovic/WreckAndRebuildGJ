using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveHorizontal;
    float moveVertical;
    [SerializeField]
    float movementSpeed = 5;
    private bool isFacingRight = true;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        Flip();
        if(moveHorizontal > 0f)
        {

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal, moveVertical).normalized * movementSpeed;
    }

    private void Flip()
    {
        if(isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
