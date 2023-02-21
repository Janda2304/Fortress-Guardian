using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
   
    
    
    public void SavePlayerData(GameObject player)
    {
        position = player.transform.position;
        rotation = player.transform.rotation;
        scale = player.transform.localScale;
    }

    public void LoadPlayerData(GameObject player)
    {
        player.transform.position = position;
        player.transform.rotation = rotation;
        player.transform.localScale = scale; 
    }
}
