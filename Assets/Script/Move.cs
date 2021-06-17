using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //-------------------------
    // Movimenta a tela
    //-------------------------

public class Move : MonoBehaviour
{
    public GameObject _button;

    public float speed;

    Parallax _component;
    
    void Start()
    {
        _component = _button.GetComponent<Parallax>();
    }

    //-------------------------
    // Codigo que faz e limita a movimentação da camera
    //-------------------------

    void Update()
    {
        // FAZ
        transform.Translate(speed * _component.input * Time.deltaTime, 0, 0);

        //LIMITA
        transform.position = new Vector3(Mathf.Clamp(transform.position.x , -17, 0), Mathf.Clamp(transform.position.y,0,0), Mathf.Clamp(transform.position.z, 100, 100));
    }
}
