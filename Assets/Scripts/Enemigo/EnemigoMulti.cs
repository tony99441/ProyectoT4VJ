using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMulti : MonoBehaviour
{
 private SpriteRenderer sr;
    private Rigidbody2D rb;

    private int camina = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (camina == 0)
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            sr.flipX = false; 
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Derecha") )
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-10, rb.velocity.y);
            camina = 1;
        }
        if (collision.gameObject.CompareTag("Izquierda") && camina ==1)
        {
            
            rb.velocity = new Vector2(10, rb.velocity.y);
            sr.flipX = false;
        }

        
    }
    
}
