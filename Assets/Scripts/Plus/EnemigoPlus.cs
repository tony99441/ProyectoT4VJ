using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemigoPlus : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    
    private const int Idle = 0;
    private const int Jump = 1;
    private const int Run = 2; 
    private const int Dead = 3;


    private BarraVida _barraVida;

    private int estaMuerto=0; 
    
    public float visionRadio;
    public float velocidad;

    private GameObject player;

    private Vector3 posicionIncial; 
    public float JumpForce =45; 
    
    private float tiempo;
    private float tiempoSaltar;
   
    public GameObject BalaDerecha;
    public GameObject BalaIzquierda; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        _barraVida = FindObjectOfType<BarraVida>();

        player = GameObject.FindGameObjectWithTag("Player");

        posicionIncial = transform.position;

    }
        // Update is called once per frame
    void Update()
    {
 
        if (_barraVida.vidaActual <= 0)
        {
            estaMuerto = 1; 
        }
        if(estaMuerto ==0){
            TiraBala();
            changeAnimation(Idle);
            Saltar();
            
            
            Vector3 target = posicionIncial;
          

            // Cuando la distancia sea menor, simplemente ahora la pocicion va a ser el jugador es por 
            // eso que lo sigue. 
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < visionRadio)
            {
                sr.flipX =true;
                changeAnimation(Run);
                target = player.transform.position;
            }
          

            float fixedSpeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            
            Debug.DrawLine(transform.position,target, Color.gray);



        }


        if (estaMuerto == 1)
        {
            changeAnimation(Dead);
        }





    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,visionRadio);
    }
    

    private void changeAnimation(int animation)
    {
        animator.SetInteger("EstadoEnemy", animation);
    }
    
    public void TiraBala()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo >= 5)
        {
            var shuriken = sr.flipX ? BalaIzquierda : BalaDerecha;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = BalaDerecha.transform.rotation;
            Instantiate(shuriken,position,rotation);
            // sonidos.Disparo();
            tiempo = 0; 
        }
    }

    public void Saltar()
    {
        tiempoSaltar += 1 * Time.deltaTime;
        if (tiempoSaltar >= 3)
        {
            rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
            changeAnimation(Jump);
          
            tiempoSaltar = 0; 
        }
    }




}

