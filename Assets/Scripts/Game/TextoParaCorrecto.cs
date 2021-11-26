using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoParaCorrecto : MonoBehaviour
{
    public float TiempoDeMensaje = 2; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TiempoDeMensaje -= Time.deltaTime;
        if (TiempoDeMensaje <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
