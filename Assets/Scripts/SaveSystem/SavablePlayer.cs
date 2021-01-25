using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavablePlayer : MonoBehaviour
{
   public void SaveCharacter()
   {
      SaveSystem.SavePlayer(gameObject);
      
   }

   public void LoadCharacter(PlayerData data)
   {
      transform.position=new Vector3(data.position[0],data.position[1],data.position[2]);
      GetComponent<Health>().SetHealth(data.health);
   }
}
