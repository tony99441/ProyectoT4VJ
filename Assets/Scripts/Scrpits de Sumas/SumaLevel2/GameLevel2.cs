using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel2 : MonoBehaviour
{
    private string Operaciones = "";
    public Text OperacionesText;

    private int Vidas = 3;
    public Text VidasText;

    
    
    public Text tiempoText;
    public float  Tiempo = 4;
    public int tiempoToText; 

    // Start is called before the first frame update
    void Start()
    {
        OperacionesText.text = "Cuanto es: 7 + 2 ?"+ Operaciones;
        VidasText.text = "Vidas: " + Vidas;
        
        tiempoText.text = "Tiempo: " + Tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo -= Time.deltaTime;
        tiempoText.text = "Tiempo Restante: " + Tiempo.ToString("f0");

        if (Tiempo <= 0)
        {
            Debug.Log("El juego termina");
            
        }
    }
    

    public void RestaVidas(int vidas)
    {
        this.Vidas -= vidas;
        VidasText.text = "Vidas: " + Vidas;
        

    }
    public void SumaVidas(int vidas)
    {
        this.Vidas += vidas;
        VidasText.text = "Vidas: " + Vidas;
        

    }

    public void NuevaOperacion(string operacion)
    {
        OperacionesText.text = operacion; 
    }


    
    
    public void NoVidas()
    {
        VidasText.text = "No tienes vidas :(";
    }


}