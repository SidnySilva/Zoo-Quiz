using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-------------------------
// Gerenciador de Telas
//-------------------------

public class ScreenManager : MonoBehaviour
{
    public void TrocaFase(string P)
    {
        SceneManager.LoadScene(P);
    }
}
