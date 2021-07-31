using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager data:")]
    public Scene NextLevel;
    public string PlayerTag;
    
    private Scene ActualLevel;
    private PlayerStatus Status; 

    private void Update()
    {
        VerifyDeathStatus();
    }

    public Scene GetActualLevel()
    {
        return ActualLevel;
    }
    
    private void Awake()
    {
        PlayerTag ??= "Player";
        Status = GameObject.FindWithTag(PlayerTag).GetComponent<PlayerStatus>();
        ActualLevel = SceneManager.GetActiveScene();
        SaveSystem.SaveGame(new PlayerData(this));
    }

    private void ReloadOnDeath()
    {
        SceneManager.LoadScene(ActualLevel.name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel.name);
    }

    private void VerifyDeathStatus()
    {
        if (Status.IsPlayerDead) ReloadOnDeath();
    }

    

}
