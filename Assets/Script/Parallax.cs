using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    //-------------------------
    // Botão que permite a captura de toque para movimentação de tela na segunda fase
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
    // Recebe a ação do player sobre o botão para permitir a movimentação da tela
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
