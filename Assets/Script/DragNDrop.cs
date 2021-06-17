using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    //-------------------------
    // Script que permite a movimentação do animal na fase 3
    //-------------------------

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    Canvas _canvas;
    [SerializeField]
    CanvasGroup _canvasGroup;

    [SerializeField]
    RectTransform _transform;
    private RectTransform startPosition;

    public int ID;
    
    Controller col;
    ItemSlot IS;

    void Start()
    {
        IS = FindObjectOfType(typeof(ItemSlot)) as ItemSlot;
        col = FindObjectOfType(typeof(Controller)) as Controller;

        _canvasGroup = GetComponent<CanvasGroup>();
        _transform = GetComponent<RectTransform>();

    }

    //-------------------------
    // Ao clicar no animal ele é capiturado para ser movimentado
    //-------------------------

    public void OnBeginDrag(PointerEventData eventData)
    {      
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;
        Controller.Valor = ID;
    }
    
    //-------------------------
    // Permite arrastar o objeto sem perder o centro dele
    //-------------------------

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        
    }
    
    //-------------------------
    // Ao soltar devolve as propriedades do objeto
    //-------------------------

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;


    }
  
    //-------------------------
    // Retira a Dica da fase 3
    //-------------------------

    public void OnPointerDown(PointerEventData eventData)
    {
        col.Tela[9].SetActive(false);
    }

}
