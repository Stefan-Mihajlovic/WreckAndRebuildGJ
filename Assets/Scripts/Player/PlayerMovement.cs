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


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if(moveHorizontal < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal, moveVertical).normalized * movementSpeed;
    }
}
