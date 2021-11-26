using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocityX = 10f;

    private Rigidbody2D rb; 
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemigo"))
        {
            // Se destruye la bala
            Destroy(this.gameObject);
            // Se destruye el enemigo 
            Destroy(other.gameObject);
        }
        
        

        
    }
    
}
