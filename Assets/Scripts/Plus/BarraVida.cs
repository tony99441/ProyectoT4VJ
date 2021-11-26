using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI; 
public class BarraVida : MonoBehaviour
{
    public Image barraVida;

    public int vidaActual=100;

    public float vidaMaxima =100;

   
    // Para las vidas del Personaje
    private int Vidas = 5;
    public Text VidasText;

    public int VidatodalPersonaje =5; 
    // Start is called before the first frame update
    void Start()
    {
        VidasText.text = "Vidas: " + Vidas;
        barraVida.fillAmount = vidaActual / vidaMaxima; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RestaVidas(int vidas)
    {
        vidaActual -= vidas;
        Debug.Log(vidaActual);
        barraVida.fillAmount = (vidaActual-vidas) / vidaMaxima;
    }
    public void RestaVidasPersonaje(int vidas)
    {
        this.Vidas -= vidas;
        VidasText.text = "Vidas: " + Vidas;
        VidatodalPersonaje -= 1;

        if (VidatodalPersonaje<=0)
        {
            VidatodalPersonaje = 0; 
        }
    }


}
