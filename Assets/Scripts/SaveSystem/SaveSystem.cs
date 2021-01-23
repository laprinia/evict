using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    private static string filePath = Application.persistentDataPath + "/playerData.txt";

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter=new BinaryFormatter();
        FileStream fileStream=new FileStream(filePath,FileMode.Create);
        PlayerData data=new PlayerData(player);
        formatter.Serialize(fileStream,data);
        fileStream.Close();
        
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream fileStream=new FileStream(filePath,FileMode.Open);
            PlayerData playerData=formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found at " + filePath);
            return null;
        }
    }
}
