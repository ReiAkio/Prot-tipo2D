using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData
{
    public Scene SavedScene;
    
    public PlayerData(GameManager gameManager)
    {
        SavedScene = gameManager.GetActualLevel();
    }
}
