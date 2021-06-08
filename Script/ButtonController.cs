using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------
// Script dos botões da segunda e terceira fase
//-------------------------

public class ButtonController : MonoBehaviour
{
    
    public bool c;

    public Image image;
    public GameObject curiosidade;

    private bool click, Cur;

    Controller C;
    Timer T;
   
    void Start()
    {
        c = true;

        T = FindObjectOfType(typeof(Timer)) as Timer;
        C = FindObjectOfType(typeof(Controller)) as Controller;
    }

    //-------------------------
    // Se a resposta for correta habilitará esse botão
    //-------------------------

    public void Curiosi(int i)
    {
        if(Cur == false)
        {
            Cur = true;
            C.Curiosidades[i].SetActive(true);
        }
        else if(Cur == true)
        {
            Cur = false;
            C.Curiosidades[i].SetActive(false);
        }
        
    }

    //-------------------------
    // Destroi e contabiliza os animais encontrados na segunda fase
    //-------------------------

    public void Click()
    {
        C.Pontos++;
        Destroy(image);
        Destroy(gameObject);
        AudioController.PlaySounds(Sound.A);
    }

    //-------------------------
    // Ao apertar na introdução da segunda fase a mesma é destruida e inicia o temporizador
    //-------------------------

    public void IClick()
    {
        Destroy(gameObject);
        C.stop = false;
        StartCoroutine(T.Timing());
    }

    //-------------------------
    // Verifica a resposta das pergunsta da terceira fase
    //-------------------------

    public void ClickResp(int ID)
    {
        if(click == false)
        {
            // Certo
            if (ID == 1) 
            {
                click = true;
                AudioController.PlaySounds(Sound.C);
                C.Pontos++;
                StartCoroutine(Close());
                Controller.Curi.SetActive(true);
            }

            // Errado
            else if (ID == 2)
            {
                click = true;
                AudioController.PlaySounds(Sound.E);
                StartCoroutine(Close());

            }
        }
        
    }

    //-------------------------
    // Habilita os creditos
    //-------------------------

    public void creditos()
    {
        C.Intro.SetActive(true);
    }

    //-------------------------
    // Corrotina que da um tempo para habilitar a tela de perguntas 
    //-------------------------

    IEnumerator Close()
    {
        yield return new WaitForSeconds(1);
        Controller.Quest.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Controller.BoxPerg.SetActive(false);
        C.Counter++;
        click = false;
    }
}
