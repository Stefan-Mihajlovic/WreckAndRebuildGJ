using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class patrolneSape : MonoBehaviour
{
    public GameObject tackaA;
    public GameObject tackaB;
    private Rigidbody2D rb;
    public GameObject player;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(2, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 5)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * speed;
        }
        else
        {
            if (transform.position.x >= tackaB.transform.position.x)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            if (transform.position.x <= tackaA.transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
        



    }
}
