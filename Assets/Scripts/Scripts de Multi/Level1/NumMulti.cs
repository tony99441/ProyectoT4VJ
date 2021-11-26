using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumMulti : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public float JumpForce =6;

    private int estaEnSuelo = 0; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estaEnSuelo ==1)
        {
            rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
            estaEnSuelo = 0;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            estaEnSuelo = 1; 
        }
    }
}
