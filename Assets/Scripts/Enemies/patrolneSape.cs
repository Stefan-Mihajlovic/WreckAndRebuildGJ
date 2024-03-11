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
       
        



    }
}
