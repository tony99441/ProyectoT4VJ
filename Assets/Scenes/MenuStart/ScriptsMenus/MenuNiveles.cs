using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nivel1Multi()
    {
        SceneManager.LoadScene("Multi-Level1");
    }
    public void Nivel2Multi()
    {
        SceneManager.LoadScene("Multi-Level2");
    }
    public void Nivel3Multi()
    {
        SceneManager.LoadScene("Multi-Level3");
    }
    
    // Divi
    
    public void Nivel1Divi()
    {
        SceneManager.LoadScene("Division-Level1");
    }
    public void Nivel2Div()
    {
        SceneManager.LoadScene("Division-Level2");
    }
    public void Nivel3Div()
    {
        SceneManager.LoadScene("Division-Level3");
    }
    // Suma
    public void Nivel1Suma()
    {
        SceneManager.LoadScene("Suma-Level1");
    }
    public void Nivel2Suma()
    {
        SceneManager.LoadScene("Suma-Level2");
    }
    public void Nivel3Suma()
    {
        SceneManager.LoadScene("Suma-Level3");
    }
    // Resta
    public void Nivel1Resta()
    {
        SceneManager.LoadScene("Restas-Level1");
    }
    public void Nivel2Resta()
    {
        SceneManager.LoadScene("Restas-Level2");
    }
    public void Nivel3Resta()
    {
        SceneManager.LoadScene("Restas-Level3");
    }
    
}
