using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //-------------------------
    // Temporizador da 2º fase
    //-------------------------

public class Timer : MonoBehaviour
{
    public float TimeLoss, TimeMax, time;

    public Transform BarraTime;  
    public GameObject but, Over;

    ButtonController B;
    AudioController Au;
    Controller C;
    void Start()
    {
        C = FindObjectOfType(typeof(Controller)) as Controller;
        Au = FindObjectOfType(typeof(AudioController)) as AudioController;
        B = FindObjectOfType(typeof(ButtonController)) as ButtonController;
        time = TimeMax;
        B.c = true;
        StartCoroutine(Timing());

    }

    //-------------------------
    // Se o tempo chegar a zero o player perde
    //-------------------------

    void Update()
    {
    
        if (time <= 0)
        {
            Over.SetActive(true);
            Au.Sing[0].enabled = false;
            Au.Sing[1].enabled = false;
        }
    }
    
    //-------------------------
    // Corrotina que faz o tempo passar se o pause for falso
    //-------------------------

    public IEnumerator Timing()
    {
        while (C.stop != false)
        {
            yield return new WaitForSeconds(0.1f);
        }
        while (time > 0 && C.stop == false)
        {
            yield return new WaitForSeconds(1);
            TimeLoss = 1;
            Vector3 theScale = BarraTime.localScale;
            theScale.x -= TimeLoss;
            time -= TimeLoss;
            BarraTime.localScale = theScale;
        }
    }
}
