using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class patrolneSape : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public GameObject player;
    public float speed = 1f;
    public float targetTime = 2f;
    public float dashSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(targetTime <= 0)
        {
            targetTime = 3f;
            speed = 10f;
            Invoke("Slow", 0.4f);

        }
        
    }
    void Slow()
    {
        speed = 1f;
    }
    
    

}
