using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalObject : MonoBehaviour
{
    [Header("Elemental Object Settings")] 
    public Element ObjectElement;
    public Animation CurrentAnimation;
    public bool IsActive;

    // Private variables
    private Animator Animator;

    private void Awake()
    {
        // Verify if there's previous attached element
        if (ObjectElement.Equals(null))
            ObjectElement = Element.NONE; // Set the default element

        // Verify if the object is supposed to be active
        if (IsActive.Equals(null)) IsActive = false;
        // Adjust activity of the object
        gameObject.SetActive(IsActive);
        
        // Verify animation and play it
        if (!CurrentAnimation.Equals(null)) Animator.Play(CurrentAnimation.name);
    }
}
