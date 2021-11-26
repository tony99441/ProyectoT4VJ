using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocityX = -14f;

    private Rigidbody2D rb;

    private BarraVida _barraVida;
    private Sonidos sonidos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _barraVida = FindObjectOfType<BarraVida>();
        sonidos = FindObjectOfType<Sonidos>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag != "Enemigo")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // Se destruye la bala
            Destroy(this.gameObject);
        _barraVida.RestaVidasPersonaje(1);
        sonidos.MenosVida();
        
        }
        
        

        
    }

  

}
