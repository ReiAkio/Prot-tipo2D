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
}
