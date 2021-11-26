using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyMultiLevel2 : MonoBehaviour
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
    private int vidasRestantes = 3;

    private GameMultiLevel1 _gameController;
    private Sonidos sonidos;


    public GameObject TextoFlotante;

    private const  string tag1 = "Num1" ;
    private const int Num1 = 1; 
    
    private const  string tag2 = "Num2" ;
    private const int Num2 = 2; 
    
    private const  string tag3 = "Num3" ;
    private const int Num3 = 3; 
    
    private const  string tag4 = "Num4" ;
    private const int Num4 = 4; 
    
    private const  string tag5 = "Num5" ;
    private const int Num5 = 5; 

    private const  string tag6 = "Num6" ;
    private const int Num6 = 6; 

    private const  string tag7 = "Num7" ;
    private const int Num7 = 7; 

    private const  string tag8 = "Num8" ;
    private const int Num8 = 8; 

    private const  string tag9 = "Num9" ;
    private const int Num9 = 9; 

    private const  string tag10 = "Num10" ;
    private const int Num10 = 10; 

    private const  string tag11 = "Num11" ;
    private const int Num11 = 11; 

    private const  string tag12 = "Num12" ;
    private const int Num12 = 12; 
    
    private const  string tag13 = "Num13" ;
    private const int Num13 = 13; 
    
    private const  string tag14 = "Num14" ;
    private const int Num14 = 14; 
    
    private const  string tag15 = "Num15" ;
    private const int Num15 = 15;


    private int puntosAcumulados = 0; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


        _gameController = FindObjectOfType<GameMultiLevel1>();
        sonidos = FindObjectOfType<Sonidos>();
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

        if (_gameController.Tiempo<=0 )
        {
            changeAnimation(Dead);
            sonidos.Muere();
        }

        if (estaMuerto == 1)
        {
            changeAnimation(Dead);
            sonidos.Muere();
        }

       
     


    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            _gameController.RestaVidas(1);
            vidasRestantes -= 1;
            EsIntengible = true;
            sonidos.MenosVida();
        }

        if (vidasRestantes <=0)
        {
            estaMuerto = 1;
            _gameController.NoVidas();
            
        }
      
        
        if (collision.gameObject.CompareTag(tag1) && Num1 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
               
            }
        }
        if (collision.gameObject.CompareTag(tag2) && Num2 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
                
            }
        }

        if (collision.gameObject.CompareTag(tag3) && Num3 == _gameController.ResulOperacion)
        {
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
               
            }
            _gameController.NumerosAleatorios();
        }
        if (collision.gameObject.CompareTag(tag4) && Num4 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag5) && Num5 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag6) && Num6 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag7) && Num7 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag8) && Num8 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag9) && Num9 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag10) && Num10 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag(tag11) && Num11 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag("Num12") && Num12 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag("Num13") && Num13 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag("Num14") && Num14 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }
        if (collision.gameObject.CompareTag("Num15") && Num15 == _gameController.ResulOperacion)
        {
            _gameController.NumerosAleatorios();
            Destroy(collision.gameObject);
            sonidos.Punto();
            _gameController.SumaPuntos(1);
            puntosAcumulados += 1; 
            if (TextoFlotante)
            {
                MonstrarTextoFlotante();
            }
        }

        if (puntosAcumulados ==4)
        {
            Debug.Log("Ya acumuló todos los puntos, falta la llave");
           
        }








        if (collision.gameObject.CompareTag("Llave") && puntosAcumulados >=4)
        {

            SceneManager.LoadScene("Multi-Level3");
        }

        
        if (collision.gameObject.CompareTag("Vida"))
        {
            _gameController.SumaVidas(1);
            Destroy(collision.gameObject);
            sonidos.Vida();
            
        }

        



    }
    
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    public void MonstrarTextoFlotante()
    {
        GameObject textflotante = Instantiate(TextoFlotante);
        textflotante.transform.position = new Vector3(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y+4, this.gameObject.transform.position.z);
    }
    
    

}