using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorVerifier : MonoBehaviour
{
    private SpriteRenderer Renderer;

    private void Awake()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        var Aux1 = gameObject.GetComponent<PlayerStatus>();
        if (Aux1)
            VerifyColor(Aux1.PlayerCurrentElement);
        var Aux2 = gameObject.GetComponent<TrapScript>();
        if (Aux2)
            VerifyColor(Aux2.ObjectElement);
        var Aux3 = gameObject.GetComponent<ElementScript>();
        if (Aux3)
            VerifyColor(Aux3.ObjectElement);
    }

    private void VerifyColor(Element currentElement)
    {
        if (currentElement == Element.NONE)
            Renderer.color = Color.gray;
        if (currentElement == Element.GEO)
            Renderer.color = Color.yellow;
        if (currentElement == Element.HYDRO)
            Renderer.color = Color.blue;
        if (currentElement == Element.ELECTRO)
            Renderer.color = Color.magenta;
        if (currentElement == Element.PYRO)
            Renderer.color = Color.red;
    }
}
