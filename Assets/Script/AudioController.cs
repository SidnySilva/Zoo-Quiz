using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------
// Controlador de audio
//-------------------------

public enum Sound
{
    C, E, A, W, L
}
public class AudioController : MonoBehaviour
{
    public AudioClip certo, errado, achou, win, lose;
    public AudioSource[] Sing;
    public AudioSource audi;

    public static AudioController instance;

    Controller Controller;

    void Start()
    {
        audi = GetComponent<AudioSource>();
        Controller = FindObjectOfType(typeof(Controller)) as Controller;
        instance = this;
    }


    //-------------------------
    // Verifica que música será tocada
    //-------------------------

    void Update()
    {
        if (Controller.count == 0)
        {
            Sing[0].enabled = true;
            Sing[1].enabled = false;
        }
        else if (Controller.count == 1)
        {
            Sing[0].enabled = false;
            Sing[1].enabled = true;
        }
    }


    //-------------------------
    // Gerencia e prepara os audios para o momento que for chamado
    //-------------------------


    public static void PlaySounds(Sound currentSound)
    {
        switch (currentSound)
        {
            case Sound.C:
                instance.audi.PlayOneShot(instance.certo);
                break;

            case Sound.E:
                instance.audi.PlayOneShot(instance.errado);
                break;
            case Sound.W:
                instance.audi.PlayOneShot(instance.win);
                break;
            case Sound.A:
                instance.audi.PlayOneShot(instance.achou);
                break;
            case Sound.L:
                instance.audi.PlayOneShot(instance.lose);
                break;
        }
    }

    //Fuñções na fase 3

    //-------------------------
    // Para de tocar
    //-------------------------

    public void stop()
    {
        Sing[0].volume = 0;
    }

    //-------------------------
    // Começa a tocar
    //-------------------------

    public void restart()
    {
        Sing[1].enabled = false;
    }
}
