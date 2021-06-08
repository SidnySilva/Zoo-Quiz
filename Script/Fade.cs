using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //-------------------------
    // Efeito onde faz uma imagem perder a cor gradualmente
    //-------------------------

public class Fade : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(FadeOut());
    }

    //-------------------------
    // Aparecer
    //-------------------------

    public IEnumerator FadeIn()
    {
        for(float f = 0;f <= 1; f+=0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }
    }

    //-------------------------
    // Desaparecer
    //-------------------------

    public IEnumerator FadeOut()
    {
        for (float f = 1; f >= 0; f -= 0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return null;
        }
    }
}
