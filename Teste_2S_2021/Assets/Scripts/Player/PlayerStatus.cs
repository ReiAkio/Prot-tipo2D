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
        if (PlayerCurrentElement.Equals(null))
            PlayerCurrentElement = Element.NONE;
        PlayerCurrentScene = SceneManager.GetActiveScene();
        IsPlayerDead = false;
    }
}
