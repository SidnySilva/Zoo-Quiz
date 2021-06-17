using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    //-------------------------
    // Onde aloca o e verifica animal na terceira fase
    //-------------------------

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    RectTransform _transform;
    public GameObject Pergunta;
    public GameObject OwnQuestion;
    public GameObject Curiosidade;
    public int Question;
    public int ID;

    Controller col;

    void Start()
    {
        Pergunta.SetActive(false);
        col = FindObjectOfType(typeof(Controller)) as Controller;
    }

    //-------------------------
    // Ao soltar o animal dentro do espaço, logo o mesmo será verificado
    //-------------------------

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
        col.Next3();
        WhichAnimal();
    }

    //-------------------------
    // Verificação para certo ou errado
    //-------------------------

    public void WhichAnimal()
    {

        if (ID == Controller.Valor)
        {
            StartCoroutine(Correto());
        }
        else
        {
            StartCoroutine(Errado());
        }
    }

    //-------------------------
    // Corrotina de certo e errado e as funções para serem mostradas na tela
    //-------------------------

    //CERTO
    public IEnumerator Correto()
    {
        if(Question == 0)
        {
            Question++;
            Controller.Quest = OwnQuestion;
            Controller.BoxPerg = Pergunta;
            Controller.Curi = Curiosidade;
            col.Certo.SetActive(true);
            yield return new WaitForSeconds(1);
            col.Certo.SetActive(false);
            Pergunta.SetActive(true);
            OwnQuestion.SetActive(true);
        }
        
    }

    //ERRADO
    public IEnumerator Errado()
    {
        col.Errado.SetActive(true);
        yield return new WaitForSeconds(1);
        col.Errado.SetActive(false);

    }
}
