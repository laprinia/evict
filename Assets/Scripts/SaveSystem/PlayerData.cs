using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;

    public PlayerData(Player player)
    {
        health = player.GetComponent<Health>().curHealth;
        Vector3 currentPosition=player.transform.position;
        position[0] = currentPosition.x;
        position[1] = currentPosition.y;
        position[2] = currentPosition.z;
    }
}
