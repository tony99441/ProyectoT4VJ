using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Suma-Level1");
    }

    
    
    public void Pluss()
    {
        SceneManager.LoadScene("Pluss");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del Juego");
    }
}
