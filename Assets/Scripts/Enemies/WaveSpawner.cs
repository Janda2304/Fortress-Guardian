using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject boar;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject goblinWithCannon;
    [SerializeField] private GameObject goblinOnBoar;
    


    void Start()
    {
       Wave1();
    }

    IEnumerator SpawnGoblin()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2);
            Instantiate(goblin, goblin.GetComponent<EnemyAI>().spawnpoint, Quaternion.identity);
            
        }
        
    
        


    }


    private void Wave1()
    {
        StartCoroutine(SpawnGoblin());
    }
    
    
    
}
