using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------
// Controlador geral
//-------------------------

public class Controller : MonoBehaviour
{
    //Verificador que permite a associação para o Script ItemSlot
    public static int Valor;

    public static GameObject Quest, BoxPerg, Curi;

    public int count = 0;
    public int Counter = 0;
    public int Pontos = 0;
    public int Current = 1;
    [Header("Botao troca")]
    public GameObject botao;
    [Header("Fases")]
    public GameObject Fase1;
    public GameObject Fase2;

    [Header("Perg/Resp")]
    public Text Resp, Fim;

    [Header("Panel")]
    public GameObject[] animais, animais2, Curiosidades, ButCuri;
    public GameObject[] Tela;
    public GameObject Block;
    public GameObject Proximo, ProximoF;
    public GameObject BG;
    public GameObject Pause, Certo, Errado;
    public GameObject Intro;
    public bool[] animal;
    public bool stop;
    public bool fase1, fase2, fase3, resp;

    AudioController AudioController;
    Timer T;
    AudioController Au;




    void Start()
    {
        stop = true;

        Au = FindObjectOfType(typeof(AudioController)) as AudioController;
        T = FindObjectOfType(typeof(Timer)) as Timer;
        AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;

        Pause.SetActive(false);

        //-------------------------
        // Reajusta a lista de animais para falso
        //-------------------------

        for (int i = 0; i < animais.Length; i++)
        {
            animais[i].SetActive(false);
        }
        resp = true;

    }
    private void Update()
    {
        Next3();

        //-------------------------
        // Define a resposta final de acordo com os acertos do jogador
        //-------------------------

        if (fase1 == true)
        {

            if (Pontos == 0)
            {
                Fim.text = "Poxa vida, não acertamos nenhum, vamos tentar de novo!!";
            }
            else if (Pontos > 0 && Pontos <= 6)
            {
                Fim.text = "Encontramos alguns animais!! Que tal a gente tentar encontrar mais!!";
            }
            else if (Pontos > 6 && Pontos <= 9)
            {
                Fim.text = "Eita!! Chegamos perto dessa vez!! ";
            }
            else if (Pontos == 10)
            {
                Fim.text = "Parabéns, encontramos todos os animais!!";
            }


        }

        if (fase2 == true)
        {
            if (Pontos == 16)
            {
                StartCoroutine(Concluiu());
            }

        }
    }

    //-------------------------
    // Troca a fase dentro da primeira fase
    //-------------------------

    public void TrocaTela()
    {
        if (count == 0)
        {
            Pause.SetActive(true);
            Block.SetActive(false);
            Resp.text = " ";
            Tela[1].SetActive(true);
            BG.SetActive(true);
            Tela[0].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 1)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[2].SetActive(true);
            Tela[1].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 2)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[3].SetActive(true);
            Tela[2].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 3)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[4].SetActive(true);
            Tela[3].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 4)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[5].SetActive(true);
            Tela[4].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 5)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[6].SetActive(true);
            Tela[5].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 6)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[7].SetActive(true);
            Tela[6].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 7)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[8].SetActive(true);
            Tela[7].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 8)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[9].SetActive(true);
            Tela[8].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 9)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[10].SetActive(true);
            Tela[9].SetActive(false);
            Proximo.SetActive(false);
            count++;
        }
        else if (count == 10)
        {
            Block.SetActive(false);
            Resp.text = " ";
            Tela[11].SetActive(true);
            Tela[10].SetActive(false);
            Proximo.SetActive(false);
            Pause.SetActive(false);

            //-------------------------
            // Se o player acertar todas as perguntas ele habilitará a passagem para a segunda fase
            //-------------------------

            if (Pontos >= 10)
            {
                ProximoF.SetActive(true);
                Au.Sing[1].enabled = false;
                Au.Sing[2].enabled = true;
            }
            else
            {
                Au.Sing[1].enabled = false;
                Au.Sing[3].enabled = true;
            }
            for (int i = 0; i < animal.Length; i++)
            {
                if (animal[i] == true)
                {
                    animais[i].SetActive(true);
                }
            }


        }
    }

    //-------------------------
    // Tela para fechar o jogo na versão mobile
    //-------------------------

    public void ConfirmFechar()
    {
        Tela[13].SetActive(true);
    }

    //-------------------------
    // Fecha o jogo nom mobile
    //-------------------------

    public void FecharJogo()
    {
        Application.Quit();
    }

    //-------------------------
    // Reseta os animais e fases para reiniciar o desafio
    //-------------------------

    public void SetFalse()
    {

        for (int i = 0; i < animal.Length; i++)
        {
            animal[i] = false;
        }

        for (int i = 1; i < Tela.Length; i++)
        {
            Tela[i].SetActive(false);
        }

        for (int i = 0; i < animais.Length; i++)
        {
            animais[i].SetActive(false);
        }
    }

    //-------------------------
    // Troca a fase da primeira para segunda
    //-------------------------

    public void NextFase(int ID)
    {
        if (ID == 1)
        {
            Fase1.SetActive(true);
        }
        else if (ID == 2)
        {
            Fase2.SetActive(true);
            count++;
        }
        else if (ID == 3)
        {
            Fase2.SetActive(false);
            count--;
        }
        else if (ID == 4)
        {
            Tela[1].SetActive(true);
            Current++;
            Fase2.SetActive(false);

        }
    }

    //-------------------------
    // Controlador de pontos da fase 3
    //-------------------------

    public void Next3()
    {
        if (fase3 == true)
        {
            if (Tela[1].activeInHierarchy)
            {
                BG.SetActive(true);
            }

            //-------------------------
            // Chama o botão para prosseguir dentro da fase 3
            //-------------------------

            if (Counter == 3 && count == 1 || Counter == 5 && count == 2 || Counter == 7 && count == 3 || Counter == 10 && count == 4 ||
                Counter == 13 && count == 5 || Counter == 16 && count == 6 || Counter == 17 && count == 7)
            {
                Proximo.SetActive(true);
            }
        }


    }

    //-------------------------
    // Reinicia os botões de curiosidade
    //-------------------------

    public void NextTela3()
    {
        count++;
        Current++;
        Proximo.SetActive(false);
        for (int i = 0; i == Curiosidades.Length; i++)
        {
            ButCuri[i].SetActive(false);
        }
        if (count <= 7)
        {
            for (int i = Current; i < Current + 1; i++)
            {
                Tela[i].SetActive(true);

            }
        }
        else if (count == 8)
        {
            Au.Sing[1].enabled = false;
            Block.SetActive(false);
            ProximoF.SetActive(true);
        }

    }

    //-------------------------
    // Leva o player para o inicio do jogo
    //-------------------------

    public void Principal()
    {
        Tela[0].SetActive(true);
        Au.Sing[3].enabled = false;
        Au.Sing[2].enabled = false;
        BG.SetActive(false);
        Pause.SetActive(false);
        ProximoF.SetActive(false);
        Block.SetActive(false);
        Resp.text = "";
        Proximo.SetActive(false);
        Tela[15].SetActive(false);
        count = 0;
        Pontos = 0;
        SetFalse();
        Fase1.SetActive(true);
    }

    //-------------------------
    // Pausa o jogo
    //-------------------------

    public void Botaopause()
    {
        Tela[12].SetActive(true);
        Pause.SetActive(true);
        stop = true;
    }

    //-------------------------
    // Desabilita o pause e volta ao jogo
    //-------------------------

    public void Continue()
    {
        
        Tela[13].SetActive(false);
        Tela[12].SetActive(false);
        stop = false;
        if (fase2 == true)
            StartCoroutine(T.Timing());

    }

    //-------------------------
    // Corrotina para habilitar a vitória quando conquistada
    //-------------------------

    IEnumerator Concluiu()
    {
        AudioController.Sing[0].enabled = false;
        AudioController.Sing[2].enabled = true;
        AudioController.PlaySounds(Sound.W);
        yield return new WaitForSeconds(1);
        ProximoF.SetActive(true);
        T.time = 100;
        count = 1;
    }

    //-------------------------
    // Define o gameObject se ele é correto ou não e devolve ao player
    //-------------------------

    public void ClickResp(int ID)
    {
        if (ID == 1)
        {
            Resp.text = "Errou";
            Proximo.SetActive(true);
            Block.SetActive(true);
            AudioController.PlaySounds(Sound.E);
        }

        else if (ID == 2)
        {
            Resp.text = "Acertou";
            Proximo.SetActive(true);
            Pontos++;
            AudioController.PlaySounds(Sound.C);
            Block.SetActive(true);
            for (int i = 0; i <= animal.Length; i++)
            {
                if (count == i)
                {
                    animal[i - 1] = true;
                }
            }
        }
    }


}
