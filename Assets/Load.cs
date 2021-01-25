using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private bool hasStartedGame;
    private void OnGUI()
    {
        if (MainMenu.isContinue&& !hasStartedGame)
        {
            LoadCharacter();
            hasStartedGame = true;
        } 
    }
    public void LoadCharacter()
    {
        PlayerData data = SaveSystem.LoadPlayerData();
        GameObject.Find("Player").GetComponent<SavablePlayer>().LoadCharacter(data);
    }
}
