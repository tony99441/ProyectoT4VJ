using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRestaLevel3 : MonoBehaviour
{
    public Text OperacionesText;

    private int Vidas = 3;
    public Text VidasText;

    private int Puntos; 
    public Text PuntosText;
    
    
    public Text tiempoText;
    public float  Tiempo = 4;
    
    // Start is called before the first frame update

    private int x, y, z;

    public int ResulOperacion; 
    void Start()
    {
        NumerosAleatorios();

        VidasText.text = "Vidas: " + Vidas;
        tiempoText.text = "Tiempo: " + Tiempo;
        PuntosText.text = "Puntos: " + Puntos; 
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

    public void SumaPuntos(int puntos)
    {
        this.Puntos += puntos;
        PuntosText.text = "Puntos: " + Puntos;
        
    }

    
    public void NoVidas()
    {
        VidasText.text = "No tienes vidas :(";
    }


    public void NumerosAleatorios()
    {
        x = Random.Range(6, 8);
        y = Random.Range(1, 5);
        OperacionesText.text = "Cuanto es: " + x + " " + " - " + y + "?";
        ResulOperacion = x - y;
         
         
         
    }
    
    
    
   

}
