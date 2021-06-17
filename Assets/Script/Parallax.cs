using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    //-------------------------
    // Bot�o que permite a captura de toque para movimenta��o de tela na segunda fase
    //-------------------------

public class Parallax : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image bg;  
    public GameObject Para;

    public float speed;
    public float input;
    public float sensibility = 3;

    bool pressing;

    //-------------------------
    // Recebe a a��o do player sobre o bot�o para permitir a movimenta��o da tela
    //-------------------------
    public void OnPointerDown(PointerEventData evenData)
    {
        pressing = true;

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;

    }
    void Update()
    {
        if (pressing)
        {
            input += Time.deltaTime * sensibility;
        }
        else
        {
            input -= Time.deltaTime * sensibility;
        }
        input = Mathf.Clamp(input, 0, 1);
    }
}
