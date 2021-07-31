using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player Status")] 
    public Element PlayerCurrentElement;
    public UnityEngine.SceneManagement.Scene PlayerCurrentScene;
    public bool IsPlayerDead;

    private void Awake()
    {
        // Verify if there's previous attached element
        if (PlayerCurrentElement.Equals(null))
            PlayerCurrentElement = Element.NONE;
        
        // Adjust initial variables
        PlayerCurrentScene = SceneManager.GetActiveScene();
        IsPlayerDead = false;
    }
}
