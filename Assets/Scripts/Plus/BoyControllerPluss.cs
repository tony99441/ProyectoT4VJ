using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyControllerPluss : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float velocityX;
    public float JumpForce; 
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
   
    private const int Idle = 0;
    private const int Run = 1;
    private const int Slide = 2; 
    private const int Jump = 3;
    private const int Dead = 4;
    
    //Para los sonidos

    
    private bool EsIntengible = false;
    private float EsIntangibleTime = 0f; 

    public GameObject BalaDerecha;
    public GameObject BalaIzquierda; 
    private int estaMuerto = 0;
    private int vidasRestantes = 5;
 
    
    private Sonidos sonidos;

    private BarraVida _barraVida;

    private BalaEnemigo balaenemigo;  
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        _barraVida = FindObjectOfType<BarraVida>();
        sonidos = FindObjectOfType<Sonidos>();

        balaenemigo = FindObjectOfType<BalaEnemigo>();
    }

    // Update is called once per frame
   void Update()
    {
        if (estaMuerto == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Estado",0);
            

            // ir a la izquierda
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                changeAnimation(Run);
            }

            //Ir a la derecha
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                changeAnimation(Run); 
            }
            // saltar
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                changeAnimation(Jump);
                sonidos.Salto();
            }
        
            //Slide
            if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocityX, 0); 
                changeAnimation(Slide);
            }
            if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
            {
                sr.flipX = true;
                rb.velocity = new Vector2(-velocityX, 0); 
                changeAnimation(Slide);
            }
            
            // Para que sea intangible
            if(EsIntengible && EsIntangibleTime < 3f)
            {
                EsIntangibleTime += Time.deltaTime;
                sr.enabled = !sr.enabled;
                Debug.Log(EsIntangibleTime);
                
            }

            else if (EsIntengible && EsIntangibleTime >= 3f)
            {
                EsIntengible = false;
                sr.enabled = true;
                EsIntangibleTime = 0f;
            
            }
            
            if (Input.GetKeyUp(KeyCode.C))
            {
                var shuriken = sr.flipX ? BalaIzquierda : BalaDerecha;
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotation = BalaDerecha.transform.rotation;
                Instantiate(shuriken,position,rotation);
                sonidos.Disparo();
            }
            

        }
        
        if (estaMuerto == 1)
        {
            changeAnimation(Dead);
            sonidos.Muere();
        }

        if (_barraVida.VidatodalPersonaje ==0)
        {
            estaMuerto = 1; 
        }
     


    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidasRestantes -= 1;
            _barraVida.RestaVidasPersonaje(1);
            EsIntengible = true;
            sonidos.MenosVida();
        }
      

        if (vidasRestantes <=0)
        {
            estaMuerto = 1;

        }
        
        



    }
    
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    
    

}
        
    
    
