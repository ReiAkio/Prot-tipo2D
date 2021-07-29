using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScript : ElementalObject
{
    private void Awake()
    {
        if (ObjectElement.Equals(null))
            ObjectElement = Element.NONE;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var StatusFromPlayer = other.gameObject.GetComponent<PlayerStatus>();
        if (StatusFromPlayer)
            StatusFromPlayer.PlayerCurrentElement = ObjectElement;
        else
            Debug.Log("Passa sem problemas...");
    }
}
