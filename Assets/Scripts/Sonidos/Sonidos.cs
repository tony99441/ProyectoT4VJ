using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public AudioClip[] audioClips; 
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Salto()
    {
        audioSource.clip = audioClips[0];
        audioSource.PlayOneShot(audioClips[0]);

    }
    public void Disparo()
    {
        audioSource.clip = audioClips[1];
        audioSource.PlayOneShot(audioClips[1]);

    }

    public void Muere()
    {
        audioSource.clip = audioClips[2];
        audioSource.PlayOneShot(audioClips[2]);

    }
    
    public void SubeNivel()
    {
        audioSource.clip = audioClips[3];
        audioSource.PlayOneShot(audioClips[3]);

    }

    public void Vida()
    {
        audioSource.clip = audioClips[4];
        audioSource.PlayOneShot(audioClips[4]);

    }
    public void Punto()
    {
        audioSource.clip = audioClips[5];
        audioSource.PlayOneShot(audioClips[5]);

    }
    public void MenosVida()
    {
        audioSource.clip = audioClips[6];
        audioSource.PlayOneShot(audioClips[6]);

    }

}
