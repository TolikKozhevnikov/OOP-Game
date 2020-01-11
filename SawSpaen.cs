using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpaen : MonoBehaviour
{

    public Transform SawCopy;
    public Transform SpawnPos;
    public float TimeS;
    void Start()
    {
        StartCoroutine(WaitAndSpawnS());
    }
    void Repeat()
    {
        StartCoroutine(WaitAndSpawnS());

    }
    IEnumerator WaitAndSpawnS()
    {
        yield return new WaitForSeconds(TimeS);
        Instantiate(SawCopy,SpawnPos.position, Quaternion.identity);

        Repeat();
    }
}
