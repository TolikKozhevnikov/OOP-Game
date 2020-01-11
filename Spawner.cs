using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform newEnemy;
    int CountMobs = 0;
    public int rand;
    public float health;
    public int Speed;
    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(20);
        Spawn();
    }
    void Spawn()
    {

        if (CountMobs < 4)
        {
           Instantiate(newEnemy);
            CountMobs++;
        }
       
    }
    void FixedUpdate()
    {
        
        StartCoroutine(WaitAndSpawn());
    }
    public float GetHealth()
    {
        return health = 5 + Random.Range(1, 6);
    }
    public int GetSpeed()
    {
        return Speed = 2 + Random.Range(1, 6);
    }
    void Death()
    {
        Destroy(gameObject);
    }

}
